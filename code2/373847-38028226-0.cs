    using System;
    using System.Collections.Generic;
    using System.Drawing;
    
    namespace ConsoleApplication1 {
    	class Program {
    		static void Main(string[] args) {
    			Dictionary<string,Point> r=new Dictionary<string,Point>();
    			r.Add("c3",new Point(0,1));
    			r.Add("c1",new Point(1,2));
    			r.Add("t3",new Point(2,3));
    			r.Add("c4",new Point(3,4));
    			r.Add("c2",new Point(4,5));
    			r.Add("t1",new Point(5,6));
    			r.Add("t2",new Point(6,7));
    			// Create a list of keys
    			List<string> zlk=new List<string>(r.Keys);
    			// and then sort it.
    			zlk.Sort();
    			List<Point> zlv=new List<Point>();
    			// Readd with the order.
    			foreach(var item in zlk) {
    				zlv.Add(r[item]);
    			}
    			r.Clear();
    			for(int i=0;i<zlk.Count;i++) {
    				r[zlk[i]]=zlv[i];
    			}
    			// test output
    			foreach(var item in r.Keys) {
    				Console.WriteLine(item+" "+r[item].X+" "+r[item].Y);
    			}
    			Console.ReadKey(true);
    		}
    	}
    }
