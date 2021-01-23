    public class Marker
    {
        public string WhatsHappening { get; set; } // exposed as property 
        string foo; // member field, is implicitly private
        public void DoFrobbing(Bar thingToFrob)
        {
            int localVariable;
        }
    }
