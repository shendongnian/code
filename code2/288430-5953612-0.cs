    public class Person  
    { 
        private int? age;
        public int Age {
            get {return age.Value;} // will fail if called and age is null, but that's your problem......
            set {age = value;}
        }
        public bool IsAgeSet {
            get {return age.HasValue;}
        }
    }
