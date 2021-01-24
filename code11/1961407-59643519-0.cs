public class SampleClass
    {
        public SampleClass(string property1, string property2)
        {
            this.Property1 = property1;
            this.Property2 = property2;
            this.Property3 = null;
        }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
    }
I'm not sure of what you're using it for though, but maybe if you've many different conditional use cases like this one, a class that do it all is maybe the best solution.  
Let us know.
