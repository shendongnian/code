text
		
		Every night	   in my 			dreams 	I see you, I feel you
	That's how    I know you go on
Far across the 	distance and 			places between us   
You            have                 come                    to show you go on
		
to be converted into
Every night in my dreams I see you, I feel you
That's how I know you go on
Far across the distance and places between us
You have come to show you go on
Here's my code
    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main(string text)
    	{
    		bool preserveTabs = false;
    
            //[Step 1]: Clean up white spaces around the text
            text = text.Trim();
            //Console.Write("\nTrim\n======\n" + text);
    
            //[Step 2]: Reduce repeated spaces to single space. 
            text = Regex.Replace(text, @" +", " ");
            // Console.Write("\nNo repeated spaces\n======\n" + text);
    
            //[Step 3]: Hande Tab spaces. Tabs needs to treated with care because 
            //in some files tabs have special meaning (for eg Tab seperated files)
            if(preserveTabs)
            {
                text = Regex.Replace(text, @" *\t *", "\t");
            }
            else
            {
                text = Regex.Replace(text, @"[ \t]+", " ");
            }
            //Console.Write("\nTabs preserved\n======\n" + text);
    
            //[Step 4]: Reduce repeated new lines (and other white spaces around them)
                      //into a single new line.
            text = Regex.Replace(text, @"([\t ]*(\n)+[\t ]*)+", "\n");
            Console.Write("\nClean New Lines\n======\n" + text);    
    	}
    }
