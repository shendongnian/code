    using System;
    using System.Collections.Generic;					
    public class Program
    {
    	static List<List<string>> board;
    	public static void Main()
    	{
    		Console.WriteLine("Enter Width:");
    		var width=ReadWidth();
    		var emptyText="-";
    		var fillText="*";
    		
    		board=new List<List<string>>();
    		
    		//for M we will use 4 points each with a width of [width]
    		Func<int,int,bool> p1=(row,col)=>{ 
    						int startX=width-1-row;
    						return (col>startX && col<=(startX+width));
    					};
    		Func<int,int,bool> p2=(row,col)=>{ 
    						int startX=width-1+row;
    						return (col>startX && col<=(startX+width));
    					};
    		Func<int,int,bool> p3=(row,col)=>{ 
    						int startX=(3*width)-1-row;
    						return (col>startX && col<=(startX+width));
    					};
    		Func<int,int,bool> p4=(row,col)=>{ 
    						int startX=(3*width)-1+row;
    						return (col>startX && col<=(startX+width));
    					};
    		
    		
    		
    		for(int row=0;row<=width;row++)
    		{
    			var rowChars=new List<string>();
    			for(int col=0;col<(width*5);col++)
    				rowChars.Add((p1(row,col) || p2(row,col) || p3(row,col) || p4(row,col))?fillText:emptyText);
    			board.Add(rowChars);
    		}
    		ShowOutput();
    	}
    	public static int ReadWidth()
    	{
    	Console.WriteLine("Enter Width (odd number beteween 2< Input < 1000):");
    		var widthString=Console.ReadLine();
    		int width=0;
    		if(!int.TryParse(widthString,out width) || width<2 || width >1000)
    		{
    		Console.WriteLine("The value entered is not accepted, please try again.");
    			ReadWidth();
    		}
    		return width;
    	}
    	public static void ShowOutput()
    	{
    		var sb=new System.Text.StringBuilder();
    		foreach(List<string> row in board)
    			sb.AppendLine(string.Join("",row.ToArray()));
    	
    		Console.Write(sb.ToString());
    	}
    }
