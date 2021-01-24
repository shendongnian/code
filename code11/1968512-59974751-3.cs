    [Serializable]
    class Data
    {
        public int Value { get; set; } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Ref<Data>(new Data { Value = 1234 });
            BinaryFormatter formatter = new BinaryFormatter();
          
            using (var fs = new FileStream("serialized.dat", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, (data, data));
                formatter.Serialize(fs, data);
            }
            using (var fs = new FileStream("serialized.dat", FileMode.Open, FileAccess.Read))
            {
                // Create a SurrogateSelector.
                
                formatter.SurrogateSelector = Ref<Data>.AddTo(new SurrogateSelector());
                var (data1, data2) = ((Ref<Data>, Ref<Data>))formatter.Deserialize(fs);
                var data3 = (Ref<Data>)formatter.Deserialize(fs);
                // object references from separate calls are not the same?
                // accordings to docs, same Formatter and ObjectIdGenerator should lead to the same object being deserialized.
                Debug.Assert(ReferenceEquals(data1.Value, data2.Value), "objects from same call");
                Debug.Assert(ReferenceEquals(data1.Value, data3.Value), "objects from different calls");
            }
        }
    }
