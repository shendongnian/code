    public class Effect
    {
        public int InternalId ...
        public int Index;
        public string BaseName;
        public string Name
        {
           get
           {
              return BaseName + (Index >= 0) ? " " + index : String.Empty;
           }
           set
           {
              BaseName = value;
              index = 0;
           }
        }
    }
