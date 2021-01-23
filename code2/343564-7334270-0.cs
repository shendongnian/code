    public MWRichTextBox() : base() { 
     
            // Initialize default text and background colors 
            textColor = RtfColor.Black; 
            highlightColor = RtfColor.White; 
            try
            {
            // Initialize the dictionary mapping color codes to definitions 
            rtfColor = new HybridDictionary(); 
            rtfColor.Add(RtfColor.Aqua, RtfColorDef.Aqua); 
            rtfColor.Add(RtfColor.Black, RtfColorDef.Black); 
            rtfColor.Add(RtfColor.Blue, RtfColorDef.Blue); 
            rtfColor.Add(RtfColor.Fuchsia, RtfColorDef.Fuchsia); 
            rtfColor.Add(RtfColor.Gray, RtfColorDef.Gray); 
            rtfColor.Add(RtfColor.Green, RtfColorDef.Green); 
            rtfColor.Add(RtfColor.Lime, RtfColorDef.Lime); 
            rtfColor.Add(RtfColor.Maroon, RtfColorDef.Maroon); 
            rtfColor.Add(RtfColor.Navy, RtfColorDef.Navy); 
            rtfColor.Add(RtfColor.Olive, RtfColorDef.Olive); 
            rtfColor.Add(RtfColor.Purple, RtfColorDef.Purple); 
            rtfColor.Add(RtfColor.Red, RtfColorDef.Red); 
            rtfColor.Add(RtfColor.Silver, RtfColorDef.Silver); 
            rtfColor.Add(RtfColor.Teal, RtfColorDef.Teal); 
            rtfColor.Add(RtfColor.White, RtfColorDef.White); 
            rtfColor.Add(RtfColor.Yellow, RtfColorDef.Yellow); 
            rtfColor.Add(RtfColor.WhiteSmoke, RtfColorDef.WhiteSmoke); 
     
            // Initialize the dictionary mapping default Framework font families to 
            // RTF font families 
            rtfFontFamily = new HybridDictionary(); 
            rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern); 
            rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss); 
            rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman); 
            rtfFontFamily.Add(FF_UNKNOWN, RtfFontFamilyDef.Unknown); 
            }
            catch
            {
            }
            // Get the horizontal and vertical resolutions at which the object is 
            // being displayed 
            using(Graphics _graphics = this.CreateGraphics()) { 
                xDpi = _graphics.DpiX; 
                yDpi = _graphics.DpiY; 
            } 
        } 
