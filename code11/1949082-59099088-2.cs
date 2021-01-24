     public class Floor : Element
        {
            public double Area { get; set; }
            public double Slope { get; set; }
    
            //Constructor
            public Floor(string name) : base(name)
            {
                SetBadParameters();
            }
    
            public void SetBadParameters()
            {
                BadParameters = GetBadParameters();//Calling base GetBadParameters
            }
        }
