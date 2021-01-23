    RichTextBox rtb = new RichTextBox();
    //this just gets the textbox to populate its Rtf property... may not be necessary in typical usage
    rtb.AppendText("blah");
    rtb.Clear();
    
    string rtf = rtb.Rtf;
    
    //exclude the final } and anything after it so we can use Append instead of Insert
    StringBuilder richText = new StringBuilder(rtf, 0, rtf.LastIndexOf('}'), rtf.Length /* this capacity should be selected for the specific application */);
    
    for (int i = 0; i < 5; i++)
    {
    	string lineText = "example text" + i;
    	richText.Append(lineText);
    	//add a \line and CRLF to separate this line of text from the next one
    	richText.AppendLine(@"\line");
    }
    
    //Add back the final } and newline
    richText.AppendLine("}");
    
    
    System.Diagnostics.Debug.WriteLine("Original RTF data:");
    System.Diagnostics.Debug.WriteLine(rtf);
    
    System.Diagnostics.Debug.WriteLine("New Data:");
    System.Diagnostics.Debug.WriteLine(richText.ToString());
    
    
    //Write the RTF data back into the RichTextBox.
    //WARNING - .NET will reformat the data to its liking at this point, removing
    //any unused colors from the color table and simplifying/standardizing the RTF.
    rtb.Rtf = richText.ToString();
    
    //Print out the resulting Rtf data after .NET (potentially) reformats it
    System.Diagnostics.Debug.WriteLine("Resulting Data:");
    System.Diagnostics.Debug.WriteLine(rtb.Rtf);
