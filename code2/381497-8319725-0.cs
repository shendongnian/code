    using System;
    using System.Linq;
    
    class Sample {
        static object junk(){
            var widgets = new { URL = new Uri("http://test.com/"), Category = "address" };
            return widgets;
        }
        static void Main(){
            dynamic widgets = junk();//var widgets = .. //NG
            Console.WriteLine(widgets.URL);
        }
    }
