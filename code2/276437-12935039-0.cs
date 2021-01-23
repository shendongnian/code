            string r = "";
            
            // WPF incl Adobe and OpenType
            foreach (System.Windows.Media.FontFamily fontFam in System.Windows.Media.Fonts.SystemFontFamilies)
            {
                r += fontFam.Source;
                r += ElementSeparator;
            }
            // True type, incl Type face names e.g. Arial Rounded MT Bold
            foreach (System.Drawing.FontFamily f in System.Drawing.FontFamily.Families)
            { 
                if(!r.Contains(f.Name))
                {
                r += f.Name;
                r += ElementSeparator;
                }
            }            
            
            return r;
        }  
