    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace LOH_RegEx
    {
    	internal class Program
    	{
    		private static List<string> storage = new List<string>();
    		private const int ChunkSize = 100000;
    		private static StringBuilder _sb = new StringBuilder(ChunkSize * 5);
    
    
    		private static void Main(string[] args)
    		{
    			var pinnedText = new string(' ', ChunkSize * 10);
    			var sourceCodePin = GCHandle.Alloc(pinnedText, GCHandleType.Pinned);
    
    			var rgx = new Regex("A", RegexOptions.CultureInvariant | RegexOptions.Compiled);
    
    			try
    			{
    
    				for (var i = 0; i < 30000; i++)
    				{					
    					//Simulate that we read data from stream to SB
    					UpdateSB(i);
    					CopyInto(pinnedText);					
    					var rgxMatch = rgx.Match(pinnedText);
    
    					if (!rgxMatch.Success)
    					{
    						Console.WriteLine("RegEx failed!");
    						Console.ReadLine();
    					}
    
    					//Extra buffer to fragment LoH
    					storage.Add(new string('z', 50000));
    					if ((i%100) == 0)
    					{
    						Console.Write(i + ",");
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex.ToString());
    				Console.WriteLine("OOM Crash!");
    				Console.ReadLine();
    			}
    		}
    
    
    		private static unsafe void CopyInto(string text)
    		{
    			fixed (char* pChar = text)
    			{
    				int i;
    				for (i = 0; i < _sb.Length; i++)
    				{
    					pChar[i] = _sb[i];
    				}
    
    				pChar[i + 1] = '\0';
    			}
    		}
    
    		private static void UpdateSB(int extraSize)
    		{
    			_sb.Remove(0,_sb.Length);
    
    			var rnd = new Random();
    			for (var i = 0; i < ChunkSize + extraSize; i++)
    			{
    				_sb.Append((char)rnd.Next(60, 80));
    			}
    		}
    	}
    }
