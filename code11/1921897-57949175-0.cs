Area = Radius* Radius * Math.PI;
Is a statement but not a declaration.
It needs to go in some sort of method.
    class Circle : Shape
    {
        public string Colour { get; set; }
        public double Radius { get; set; }
        public Circle()
        {
           Area = Radius * Radius * Math.PI;
        }
     }
