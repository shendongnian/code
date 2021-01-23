        public class Variables
        {
            // code as in your example
            public string LensValueNeeded 
            { 
              get { return LensNeeded.ToString(); }
              set { Calc(); }  // modify calc to read the text values
            }
            
            /// same for the other 3 values
        }
