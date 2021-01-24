    using System;
    using System.Text;
    
    namespace DNA
    {
    	public class Program
    	{
    		public static void Main()
    		{
    			var dna = "AAGCT";
    			var sb = new StringBuilder(dna.Length);
    			for(var i = dna.Length - 1; i >- 1; i--)
    			{
    				switch(dna[i])
    				{
    					case 'A':
    						sb.Append('T');
    						break;
    					case 'T':
    						sb.Append('A');
    						break;
    					case 'G':
    						sb.Append('C');
    						break;
    					case 'C':
    						sb.Append('G');
    						break;
    				}
    			}
    			var reversed = sb.ToString();
    			Console.WriteLine(reversed);
    		}
    	}
    }
