    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class SampleProgram
    {
    	
    	public class RowObject {
        	public double? var1 {get; set;}
        	public double? var2 {get; set;}
        	//Another 98 double? variables declared
        	public double? var100 {get; set;}
        }
    	
    	private static void GetRowList(RowObject obj, List<Nullable<double>> rowList)
    	{
    		rowList.Clear();
    		rowList.Add(obj.var1);
    		rowList.Add(obj.var2);
        	//Another 98 double? variables declared
    		rowList.Add(obj.var100);
    	}
    	
    	private static bool TestRow(List<Nullable<double>> rowList)
    	{
    		return rowList.Any( n => !n.HasValue );
    	}
    	
    	public static void Main(string[] args)
    	{
    		RowObject o1 = new RowObject();
    		o1.var1 = null;
    		o1.var2 = 2;
    		o1.var100 = 100;
    			
    		List<Nullable<double>> rowList = new List<Nullable<double>>();
    		
    		GetRowList(o1, rowList);
    		Console.WriteLine(TestRow(rowList));
    			
    		RowObject o2 = new RowObject();
    		o2.var1 = 1;
    		o2.var2 = 2;
    		o2.var100 = 100;
    		
    		GetRowList(o2, rowList);
    		Console.WriteLine(TestRow(rowList));
    	}
    }
