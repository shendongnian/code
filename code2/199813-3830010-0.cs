    public class MyObject
    {
        public Int32 ID { get; set; }
    
        public Int32 Quantity { get; set; }
    
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
    
            if (obj.GetType() == GetType())
            {
                MyObject tmpObject = obj as MyObject;
    
                return ID.Equals(tmpObject.ID);
            }
    
            return false;
        }
    
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
