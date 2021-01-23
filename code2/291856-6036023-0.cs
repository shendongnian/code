    [XMLSerializable]
    public class CustomDictionary
    {
        public int Key {get; set;}
        public List<Coordinate> Value {get; set;}
    }
    [XMLSerializable]
    public class Coordinate
    {
       public int X;
       public int Y;
    }
