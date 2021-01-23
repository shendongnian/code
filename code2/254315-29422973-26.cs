    public class g1 //We've created an instance of the Genre Class called "g1"
    {
        private string name;
        public string Name
        {
            get => name;
            set => name = "Hip Hop"; //instead of 'value', "Hip Hop" is written because 
                                  //'value' in 'g1' was set to "Hip Hop" by previously
                                  //writing 'g1.Name = "Hip Hop"'
        }
    }
