    class Program
    {
        static RichTextBox generalRTF = new RichTextBox();
        
        static void Main()
        {
        	string foo = @"Européen";
        	string output = ToRtf(foo);
        	Trace.WriteLine(output);
        }
        
        private static string ToRtf(string foo)
        {
        	string bar = string.Format("!!@@!!{0}!!@@!!", foo);
        	generalRTF.Text = bar;
        	int pos1 = generalRTF.Rtf.IndexOf("!!@@!!");
        	int pos2 = generalRTF.Rtf.LastIndexOf("!!@@!!");
        	if (pos1 != -1 && pos2 != -1 && pos2 > pos1 + "!!@@!!".Length)
        	{
        		pos1 += "!!@@!!".Length;
        		return generalRTF.Rtf.Substring(pos1, pos2 - pos1);
        	}
        	throw new Exception("Not sure how this happened...");
        }
    }
