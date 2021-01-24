    using System;
    public class Program
    {
    	const float FencePanelWidth = 7.24f;
    	public static void Main()
    	{
    		var FencePanelsNeed2 = (int)FencePanelWidth<FencePanelWidth?(int)FencePanelWidth+1:(int)FencePanelWidth;
    		Console.WriteLine(FencePanelsNeed2);
    	}
    }
