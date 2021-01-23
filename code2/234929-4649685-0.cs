            var installed_fonts = new InstalledFontCollection();
            var families = installed_fonts.Families;
            var allFonts = new List<string>();
            foreach(FontFamily ff in families){
                allFonts.Add(ff.Name);
            }
            allFonts.Sort();
            foreach(String s in allFonts){
                Console.WriteLine(s);
            }
