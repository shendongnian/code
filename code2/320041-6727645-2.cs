    public class Form1 : Form, IAbcForm
    {
        // use backing field when .net 2.0 does not support auto properties
        public string Abc { get;set; }
 
        public Form1() {}
        // I think your current constructor looks something like this:
        public Form1(string abc) { Abc = abc; }
    }
}
