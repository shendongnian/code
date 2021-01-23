    [Serializable]
    public class Cars
    {
        public int Model;
        public int Make;
    
        public Cars CreateDeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                return (Cars)formatter.Deserialize(ms);
            }
        }
    }
