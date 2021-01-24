        public static ObjectXpto ObjectXptoType(string filename)
        {
            ObjectXpto objectXpto = new ObjectXpto();
    
            using (StreamReader file = File.OpenText($"..\\project\\Data\\{filename}.json")) 
            {
                JsonSerializer serializer = new JsonSerializer();
                objectXpto = (ObjectXpto)serializer.Deserialize(file, typeof(ObjectXpto));
            }
            return objectXpto;
    
        }
    }
