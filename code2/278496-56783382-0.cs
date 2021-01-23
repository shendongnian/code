    putField("First_Name", "Fred");
    putField("Last_Name", "Bloggs");
    private void putField(string search, string replace) {
        foreach (Section section in doc.Sections) {
            doReplace(section.Range.Find, search, replace);
        foreach (HeaderFooter h in section.Headers) {
            doReplace(h.Range.Find, search, replace);
        }
         foreach (HeaderFooter f in section.Footers) {
            doReplace(f.Range.Find, search, replace);
        }
        }
    }
    
    private void doReplace(Find fnd, string search, string replace){
            fnd.ClearFormatting();
            fnd.Replacement.ClearFormatting();
            fnd.Forward = true;
            fnd.Wrap = WdFindWrap.wdFindContinue;
            fnd.Text = "«" + search + "»";
            fnd.Replacement.Text = replace;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);
    }
