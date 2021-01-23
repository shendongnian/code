    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace test_linq_join
    {
    	class MainClass
    	{
    		private class Cat
    		{
    		    // Auto-implemented properties.
    		    public int Age { get; set; }
    		    public string Name { get; set; }
    		}
    		private class Dog
    		{
    		    // Auto-implemented properties.
    		    public int Age { get; set; }
    		    public string Name { get; set; }
    		}
    			
    		public static void Main (string[] args)
    		{
    			// these are simple datasources with overlapped fields (i.e. columns)
    			Cat[] Cats = { new Cat { Age = 1, Name = "Leo" }, new Cat { Age = 3, Name = "Felix" } };
    			Dog[] Dogs = { new Dog { Age = 10, Name = "Old"}, new Dog { Age = 1, Name = "New" } };
    			
    			var Pets =
    				from C in Cats
    				from D in Dogs
    					select new { AgeC = C.Age, AgeD = D.Age, NameC = C.Name, nameD = D.Name };
    						
    			var F = new Form();
    			F.Controls.Add(new DataGridView { DataSource = Pets.ToList() });
    			F.ShowDialog();
    		}
    	}
    }
