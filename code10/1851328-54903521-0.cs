    using System;
    using System.Linq;
    	
    					
    public class Program
    {
    	public static void Main()
    	{
    		double[] d=new double[7]{1.0,2.0,3.0,4.0,5.0,6.0,7.0};
    		var inx=new Indexer(d,1,3);
    		foreach(var i in inx.array)
    		{
    			Console.WriteLine(i);
    		}
    		Console.WriteLine("d.LEn="+inx.array.Length);
    		Console.WriteLine("Hello World");
    	}
    	public class Indexer
        {
            public double this[int index]
            {
                get { return array[index]; }
                set { array[index] = value; }
            }
    
            public double[] array;
    
            public int Length { get { return array.Length; } }
    
            public Indexer(double[] array,int start,int length)
            {
                if (start < 0 || length<0 || array.Length-start<length) throw new ArgumentException();          
                this.array = array.ToList().GetRange(start, length).ToArray();
            }
        }
    }
 
