    var app = new Microsoft.Office.Interop.Word.Application();
    try
    {
        Document doc = app.Documents.Open(pathToFile);
        foreach (var word in doc.Words.Cast<Range>())
        {
            if (word.SpellingErrors.Count > 0)
            {
                Console.WriteLine(word.Text);
            }
        }
    }
    catch
    {
        //Use Try/Catch to avoid persisting Word processes in the event of an exception
    }
    finally
    {
        app.Quit();
    }
