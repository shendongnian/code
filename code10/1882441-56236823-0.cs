    class Program
    {
        static void Main(string[] args)
        {
            BaseObject baseObject = new BaseObject()
            {
               ID = 0,
               Name = "TEST",
               Description = "TEST"
            };
            ExtendedObject extendedObject = new ExtendedObject(baseObject);
        }
    }
    public class BaseObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ExtendedObject : BaseObject
    {
        public ExtendedObject(BaseObject baseObject)
        {
            this.ID = baseObject.ID;
            this.Name = baseObject.Name;
            this.Description = baseObject.Description;
        }
        public int Quantity { get; set; }
        public string MoreDetails { get; set; }
    }
