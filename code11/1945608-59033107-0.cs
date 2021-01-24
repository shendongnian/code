    public class TEST { 
    
       static public void Main(string[] args)
        {
            dynamic test = new ExpandoObject();
            test.Text = "test";
            test.Slab = "slab";
            Console.WriteLine(test.Text);
            Console.WriteLine(TEST.TestMethod(test));
        }
    
        static public string TestMethod(dynamic obj)
        {
            return obj.Slab;
        }
    } 
