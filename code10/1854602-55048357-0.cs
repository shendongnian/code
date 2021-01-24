      public class PersonModel
        {
    
            ///<summary>
            /// Gets or sets PersonId.
            ///</summary>
            public int Number { get; set; }
            public string IsEven { get { return Number % 2 == 0 ? "Even" : "Odd"; } }
       
           
        }
