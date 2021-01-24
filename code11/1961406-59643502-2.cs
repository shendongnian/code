    public class sampleClass
    {
        public sampleClass(){
         this.Init();
        }
    
        public string property1 {get; set;}
        public string property2 {get; set;}
        public string property3 {get; set;}
    
        private void Init()
        {
            this.property1 = "one";
            this.property2 = "two";
        }
}
