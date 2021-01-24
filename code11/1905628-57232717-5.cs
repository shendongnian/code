    public class NewsModel
    {
        //all your properties here
        public string Description { get; set; }
        public string DescriptionWithDots { get { return DoTheDots(Description); } }
        
        //the method that writes the dots
        public string DoTheDots(string input)
        {
            return input + "some dots ...";
        }
    }
