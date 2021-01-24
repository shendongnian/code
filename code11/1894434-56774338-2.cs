    public class FavoriveProductConverter : JsonConverter<FavoriteProductResponseModel>
    {
        public override FavoriteProductResponseModel ReadJson(
            JsonReader reader,
            Type objectType,
            FavoriteProductResponseModel existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var model = existingValue;
            if (model == null)
            {
                model = new FavoriteProductResponseModel();
            }
    
            // Here we deserialize the list under the hood
            // And assign it to the FavoriteProducts property.
            model.FavoriteProducts = serializer.Deserialize<List<FavoriteProduct>>(reader);
            return model;
        }
    
        public override void WriteJson(JsonWriter writer, FavoriteProductResponseModel value, JsonSerializer serializer)
        {
            if (value == null) return;
            
            // On serialization, we serialize the favorite products list instead
            serializer.Serialize(writer, value.FavoriteProducts);
        }
    }
