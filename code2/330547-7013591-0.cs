    class MyClass
    {    
        int ID; //needs for recognize the message
        int switch1; //0 or 1
        int switch2; //0 or 1
        int switch3; //0 or 1
        public int Pattern
        {
           get { return switch1 + switch2 << 1 + switch3 << 2; }
        }
    }
