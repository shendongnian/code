    [DelimitedRecord(",")]  // comma separated values
    [IgnoreFirst(1)]        // first line is assumed to be the header
    [IgnoreEmptyLines]      // ignore empty lines
    class MyClass {
        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string FirstName;
        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string LastName;
    }
    protected void Button1_Click(object sender, EventArgs e) {
        if (!FileUpload1.HasFile) {
            // No CSV file selected
            return
        }
        using (StreamReader sr = new StreamReader(FileUpload1.PostedFile.InputStream)) {
            FileHelperEngine engine = new FileHelperEngine(typeof(MyClass));
            foreach (MyClass entry in engine.ReadStream(sr)) {
                // do something
            }
        }
    }
