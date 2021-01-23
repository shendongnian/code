    public class Person 
    {
        private int? age;
        public int Age
        {
            // Will throw if age hasn't been set
            get { return age.Value; }
            // Implicit conversion from int to int?
            set { age = value; }
        }
        public bool HasAge { get { return age.HasValue; } }
    }
