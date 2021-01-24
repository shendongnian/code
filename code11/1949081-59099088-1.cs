     public class Wall : Element
        {
            public double Length { get; set; }
            public bool LoadBearing { get; set; }
    
            //Constructor
            public Wall(string name) : base(name)
            {
                SetBadParameters();
            }
    
            public void SetBadParameters()
            {
                BadParameters = GetBadParameters();//Calling base GetBadParameters
            }
        }
