    using System;
    using System.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    			string value="⁸ ⁹ ⁺ ⁻ ⁼ ⁽ ⁾ ₀ ₁ ₂ ₃ ₄ ₅ ₆ ₇ ₈ ₉ ₊ ₋ ₌ ₍ ₎ ®";
    		    StringBuilder sb = new StringBuilder();
    			foreach (char c in value)
    			{
    				if (c > 127)
    				{
    					string encodedtext = ((int)c).ToString("x4");
    					string encodedValue = @"\u" + encodedtext.ToUpper();
    					sb.Append(encodedValue);
    					//Console.WriteLine(encodedValue);
    				}
    				else
    				{
    					sb.Append(c);
    				}
    			}
    			Console.WriteLine(sb.ToString());
    	}
    }
