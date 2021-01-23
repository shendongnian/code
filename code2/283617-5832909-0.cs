    public class Packet
    {
        private int data, time, id;
        public string DisplayData {get {return FunctionToFormatDataToMyNeeds(data); }}
        // ...
        [Browsable(false)]
        public int Time{get{return time;}}
    }
