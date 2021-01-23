    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    public static class Test
    {
        public static void Main()
        {
            dynamic model = new ExpandoObject();
            model.Data = "asdf";
            List<dynamic> listOfx = new List<dynamic>();
            for (int i = 0; i < 3; i++)
            {
                dynamic x = new ExpandoObject();
                x.ID = i;
                x.Name = "test" + i.ToString();
                listOfx.Add(x);
            }
            model.listOfx = listOfx;
        // Access value inside list
        Console.WriteLine(model.listOfx[1].Name);
        // Iterate through list
        foreach (var o in model.listOfx)
        {
            Console.WriteLine(o.ID);
        }
            Console.ReadKey();
        }
    }
