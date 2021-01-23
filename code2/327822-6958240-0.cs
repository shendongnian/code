    using System; 
    using System.Collections.Generic; 
    using System.Linq; using System.Text; 
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization; 
    using MongoDB.Bson.Serialization.Serializers;
    
    namespace TestDataGeneration {
        public class FieldsWrapper : IBsonSerializable
        {
            public List<DataFieldValue> DataFieldValues { get; set; }
    
    
            public object Deserialize(MongoDB.Bson.IO.BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
            {
            if (nominalType != typeof(FieldsWrapper)) throw new ArgumentException("Cannot deserialize anything but self");
            var doc = BsonDocument.ReadFrom(bsonReader);
            var list = new List<DataFieldValue>();
            foreach (var name in doc.Names)
            {
                var val = doc[name];
                if (val.IsString)
                    list.Add(new DataFieldValue {LocalIdentifier = name, Values = new List<string> {val.AsString}});
                else if (val.IsBsonArray)
                {
                    DataFieldValue df = new DataFieldValue {LocalIdentifier = name};
                    foreach (var elem in val.AsBsonArray)
                    {
                        df.Values.Add(elem.AsString);
                    }
                    list.Add(df);
                }
            }
            return new FieldsWrapper {DataFieldValues = list};
            }
    
    
            public void Serialize(MongoDB.Bson.IO.BsonWriter bsonWriter, Type nominalType, IBsonSerializationOptions options)
            {
                if (nominalType != typeof (FieldsWrapper))
                    throw new ArgumentException("Cannot serialize anything but self");
                bsonWriter.WriteStartDocument();
                foreach (var dataFieldValue in DataFieldValues)
                {
              
                    bsonWriter.WriteName(dataFieldValue.LocalIdentifier);
                    if (dataFieldValue.Values.Count != 1)
                    {
                        var list = new string[dataFieldValue.Values.Count];
                        for (int i = 0; i < dataFieldValue.Values.Count; i++)
                            list[i] = dataFieldValue.Values[i];
                        BsonSerializer.Serialize(bsonWriter, list); 
                    }
                    else
                    {
                        BsonSerializer.Serialize(bsonWriter, dataFieldValue.Values[0]); 
                    }
                }
                bsonWriter.WriteEndDocument();
            }
    
        } }
