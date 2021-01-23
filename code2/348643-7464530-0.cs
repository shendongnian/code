    TextTag tag  = new TextTag("link");
    tag.Foreground = "blue";
    tag.Underline = Pango.Underline.Single;    		
    textview1.Buffer.TagTable.Add(tag);
    		
    Gtk.TextIter iter = textview1.Buffer.GetIterAtOffset(0);		
    textview1.Buffer.InsertWithTagsByName(ref iter, "link text", "link");
