    namespace XXX
    {
         [Serializable]
        public class ItemChecklist : ICloneable
        {
        
           // [...here properties, attributes, etc....]
           
            object ICloneable.Clone()
            {
                return this.Clone();
            }
            public ItemChecklist Clone()
            {
                return (ItemChecklist)this.MemberwiseClone();
            }
    
    
        }
    }
