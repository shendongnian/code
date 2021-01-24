    public class SomeObject
    {
        public int SomeId { get; private set; }
        public string Name { get; set; }
        public SomeObject(int? id = null)
        {
            if (id.HasValue)
                SomeId = id.Value;
        }
    }
