    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<MyCustomList> list = new List<MyCustomList>();
    
                list.Add(new MyCustomList("A somename", "A Fake Postal Address"));
                list.Add(new MyCustomList("B somename", "B Fake Postal Address"));
    
                //list.Sort();
    			Console.WriteLine("descending order");
                list = list.OrderByDescending(x => x.Name).ToList();
                foreach (MyCustomList o in list)
                {
                    Console.WriteLine(o.Name + " -- " + o.PostalAddress );
                }
                Console.WriteLine("ascending order");
    			list = list.OrderBy(x => x.Name).ToList();
                foreach (MyCustomList o in list)
                {
                    Console.WriteLine(o.Name + " -- " + o.PostalAddress );
                }
    	}
    	
    	public class MyCustomList
        {
            private string name;
            private string postalAddress;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string PostalAddress
            {
                get { return postalAddress; }
                set { postalAddress = value; }
            }
            public MyCustomList(string name, string postalAddress)
            {
                this.name = name;
                this.postalAddress = postalAddress;
            }
        }
    	
    }
