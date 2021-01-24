    using System;
    using System.Collections.ObjectModel;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    
    public class HeterogenousListConverter<TItem, TList> : JsonConverter<TList>
    where TItem : notnull
    where TList : IList<TItem>, new() {
    
        public HeterogenousListConverter(params (string key, Type type)[] mappings){
            foreach(var (key, type) in mappings)
                KeyTypeLookup.Add(key, type);
        }
    
        public ReversibleLookup<string, Type> KeyTypeLookup = new ReversibleLookup<string, Type>();
    
        public override bool CanConvert(Type typeToConvert)
            => typeof(IEnumerable<IVehicle>).IsAssignableFrom(typeToConvert);
    
        public override TList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options){
    
            // Helper function for validating where you are in the JSON    
            void validateToken(Utf8JsonReader reader, JsonTokenType tokenType){
                if(reader.TokenType != tokenType)
                    throw new JsonException($"Invalid token: Was expecting a '{tokenType}' token but received a '{reader.TokenType}' token");
            }
    
            validateToken(reader, JsonTokenType.StartArray);
    
            var results = new TList();
        
            reader.Read(); // Advance to the first object after the StartArray token. This should be either a StartObject token, or the EndArray token. Anything else is invalid.
            
            while(reader.TokenType == JsonTokenType.StartObject){ // Start of 'wrapper' object
            
                reader.Read(); // Move to property name
                validateToken(reader, JsonTokenType.PropertyName);
    
                var typeKey = reader.GetString();
                
                reader.Read(); // Move to start of object (stored in this property)
                validateToken(reader, JsonTokenType.StartObject); // Start of vehicle
    
                if(KeyTypeLookup.TryGetValue(typeKey, out var concreteItemType)){
                    var item = (TItem)JsonSerializer.Deserialize(ref reader, concreteItemType, options);
                    results.Add(item);
                }
                else{
                    throw new JsonException($"Unknown type key '{typeKey}' found");
                }
    
                reader.Read(); // Move past end of item object
                reader.Read(); // Move past end of 'wrapper' object
            }
    
            validateToken(reader, JsonTokenType.EndArray);
    
            return results;
        }
    
        public override void Write(Utf8JsonWriter writer, TList items, JsonSerializerOptions options){
    
            writer.WriteStartArray();
    
            foreach (var item in items){
    
                var itemType = item.GetType();            
    
                writer.WriteStartObject();
    
                if(KeyTypeLookup.ReverseLookup.TryGetValue(itemType, out var typeKey)){
                    writer.WritePropertyName(typeKey);
                    JsonSerializer.Serialize(writer, item, itemType, options);
                }
                else{
                    throw new JsonException($"Unknown type '{itemType.FullName}' found");
                }
    
                writer.WriteEndObject();
            }
    
            writer.WriteEndArray();
        }
    }
