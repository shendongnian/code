    public abstract class BodyPart
    {
        public bool IsDecapitated { get; private set; }
    
        public BodyPart(bool isDecapitated)
        {
            IsDecapitated = isDecapitated;
        } 
    }
