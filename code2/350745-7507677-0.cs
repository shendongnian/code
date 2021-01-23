    public class MyControl: WebControl
    {
        public Test()
        {
            // Make sure to initialize the complex property or you will get a NRE
            // when you try to set the Complex-Bar property in the webpage
            Complex = new Complex();
        }
        public Complex Complex { get; set; }
    }
    public class Complex
    {
        public string Bar { get; set; }
    }
