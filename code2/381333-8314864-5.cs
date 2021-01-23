    Color DelphiColorToColor(uint delphiColor)
    {
    	switch((delphiColor >> 24) & 0xFF)
    	{
    		case 0x01: // Indexed
    		case 0xFF: // Error
    			return Color.Transparent;
    		
    		case 0x80: // System
    			return Color.FromKnownColor((KnownColor)(delphiColor & 0xFFFFFF));
    		
    		default:
    			var r = (int)(delphiColor & 0xFF);
    			var g = (int)((delphiColor >> 8) & 0xFF);
    			var b = (int)((delphiColor >> 16) & 0xFF);
    			return Color.FromArgb(r, g, b);
    	}
    }
    void Main()
    {
    	unchecked
    	{
    		Console.WriteLine(DelphiColorToColor((uint)(-2147483646)));
    		Console.WriteLine(DelphiColorToColor(
                    (uint)KnownColor.ActiveCaption | 0x80000000
                ));
    		Console.WriteLine(DelphiColorToColor(0x00FF8000));
    	}
    }
