    public class Person
    {
        public double MassInGrams { get; set; }
        public double HeightInMetres { get; set; }
        public static double ComputeBodyMassIndex()
        {
            // Which person are we interested in?
        }
    }
    Person p1 = new Person { MassInGrams = 76203, HeightInMetres = 1.8 };
    Person p2 = new Person { MassInGrams = 65000, HeightInMetres = 1.7 };
    double bmi = Person.ComputeBodyMassIndex();
