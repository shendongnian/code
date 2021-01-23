    public static void FindProperty(this NoteTemplateControl nc, FormControl fc, string propertyName)
    {
        var fp = fc.Property.Find(i => i.name == propertyName);
        if (fp != null)
        {
            var setter = typeof(nc)
            nc = fp.Value;
        }
    }
