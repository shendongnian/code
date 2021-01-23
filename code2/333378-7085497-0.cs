    public class ABS
    {
        public string A;
        public string B;
    
        public static bool operator ==(ABS obj, string val){return obj.A == val;}
        public static bool operator !=(ABS obj, string val){return obj.A != val;}
        public static bool operator ==(string val, ABS obj){return obj.A == val;}
        public static bool operator !=(string val, ABS obj){return obj.A != val;}
    }
