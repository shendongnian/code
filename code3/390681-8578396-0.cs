    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace stackoverflow1
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			List<String> paths=new List<String>();
    			paths.Add(@"c:\abc\pqr\tmp\sample\b.txt");
    			paths.Add(@"c:\abc\pqr\tmp\new2\c1.txt");
    			paths.Add(@"c:\abc\pqr\tmp\b2.txt");
    			paths.Add(@"c:\abc\pqr\tmp\b3.txt");
    			paths.Add(@"c:\abc\pqr\tmp\tmp2\b2.txt");
    			
    			Console.WriteLine("Found: "+ShortestCommonPath(paths));
    			
    		}
    		
    		private static String ShortestCommonPath(IList<String> list)
    		{
    			switch (list.Count)
    			{
    			case 0: return null;
    			case 1: return list[0];
    			default:
    				String s=list[0];
    				while (s.Length>0)
    				{
    					bool ok=true;
    					for (int i=1;i<list.Count;i++)
    					{
    						if (!list[i].StartsWith(s))
    						{
    							ok=false;
    							int p=s.LastIndexOf(Path.DirectorySeparatorChar);
    							if (p<0) return "";
    							s=s.Substring(0,p);
    							break;
    						}
    					}
    					if (ok) break;
    				}
    				return s;
    			}
    		}
    		
    	}
    }
