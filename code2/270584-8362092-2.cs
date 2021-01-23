        TOutput ConvertEquivalentTypes<TInput, TOutput>(TInput structure)
            where TInput : class
            where TOutput : class
        {
            TOutput result = null;
            using (Stream data = new MemoryStream())
            {
                new XmlSerializer(typeof(TInput)).Serialize(data, structure);
                data.Seek(0, SeekOrigin.Begin);
                result = (TOutput)new XmlSerializer(typeof(TOutput)).Deserialize(data);
            }
            return result;
        }
