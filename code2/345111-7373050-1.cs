    public class Landscape
    {
        public int Population { get; set; }
        public int AreaValue { get; set; }
        public string AreaUnit { get; set; }
        
        public string Area 
        {
            get 
            {
                return AreaValue.ToString() + AreaUnit;
            }
        }
    }
