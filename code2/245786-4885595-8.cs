    public enum StickerKinds
    {
         NewRoll, Enumerated, Quality
    }
    public class StickedAttribute : Attribute
    {
          public StickedAttribute(StickerKinds kind)
          {
               _kind = kind;
          }
    
          private readonly StickerKinds _kind;
    
          public StickerKinds Kind 
          {
               get { return _kind; }
          }
    }
