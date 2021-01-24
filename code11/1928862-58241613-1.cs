        public static class DataReaderX
                {
                    public static Animal ToAnimal(this System.Data.IDataRecord record, string typeName)  
                    {
                        var animal = (Animal)Activator.CreateInstance(Type.GetType($"{typeName}"), record);
                        return animal;
                    }
        }
                
