    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Comparer
    {
    	public class Process : IComparable 
    	{
    		int last_prediction;
    		public Process(int p)
    		{
    			this.last_prediction = p;
    		}
    		public int CompareTo(object obj)
    		{
    			Process right = obj as Process;
    			return this.last_prediction.CompareTo(right.last_prediction);
    		}
    		public int Prediction { get { return this.last_prediction; } }
    	}
    	
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			List<Process> list = new List<Process>();
    			for (int i = 0; i < 10; i++)
    				list.Add(new Process(10 - i));
    			
    			System.Console.WriteLine("Current values:");
    			foreach (Process p in list)
    				System.Console.WriteLine("Process {0}", p.Prediction);
    			
    			list.Sort();
    			
    			System.Console.WriteLine("Sorted values:");
    			foreach (Process p in list)
    				System.Console.WriteLine("Process {0}", p.Prediction);
    		}
    	}
    }
