    public class test {
    
        public test(test o)
        {
          aa = o.aa;
          bb = o.bb;
        }
    
        public string aa { get; set; }
        public string bb { get; set; }
        public string cc { get; set; }
    }
    
    var a = new test {
        aa = "a",
        bb = "b"
    }
    
    var d = new test(a) {cc = "c"};
