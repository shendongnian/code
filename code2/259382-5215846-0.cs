    void Compare()
    {
        textCompare.RemoveAll(x => string.IsNullOrEmpty(x));
        List<string> matches= textInput.Intersect(textCompare).ToList();
        matches.ForEach(x=> streamWriter.WriteLine(x));
        doneLabel.Text = "Done!";
    }  
