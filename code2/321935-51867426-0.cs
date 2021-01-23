    try
    {
        wordApp = (word.Application) Marshal.GetActiveObject("Word.Application");
    }
    catch(COMException ex) when (ex.HResult == -2147221021)
    {
        wordApp = new word.Application();
    }
