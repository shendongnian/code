Area = Radius* Radius * Math.PI;
...is a statement but not a declaration.
It needs to go in *some sort* of method. 
The rest of the work is left to the reader. The following merely illustrates placing a statement in a method, which is part of what's at stake.
    class Circle : Shape
    {
        public string Colour { get; set; }
        public double Radius { get; set; }
        void DoSomething()
        {    
           //Assume Radius has a value at this point...
           Area = Radius * Radius * Math.PI;
        }
     }
