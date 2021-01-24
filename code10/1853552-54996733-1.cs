    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		
		    List<TestClass> lst1 = new List<TestClass>();
		    lst1.Add(new TestClass(){name="One", count = 1});
		    lst1.Add(new TestClass(){name="Two", count = 2});
		    lst1.Add(new TestClass(){name="Three", count = 3});
		
		    List<TestClass> lst2 = new List<TestClass>();
		    lst2.Add(new TestClass(){name="Four", count = 4});
		    lst2.Add(new TestClass(){name="Two", count = 2});
		    lst2.Add(new TestClass(){name="Three", count = 3});
		
		    var unionlst = lst1.Union(lst2, new TestClassComparer ());
		
		    foreach(var x in unionlst){
			    Console.WriteLine(x.name + ","+x.count);
		    }
	    }
	
        class TestClassComparer : IEqualityComparer<TestClass>
        { 
            public bool Equals(TestClass p1, TestClass p2)
            {
                return p1.name == p2.name && p1.count == p2.count;
            }
            public int GetHashCode(TestClass p)
            {
                return p.count;
            }
        }
	
	    public class TestClass {
    	    public string name{ get; set; }
    	    public int count{ get; set; }
	    }
    }
