    public static void Main()
    {
        var filename = "whatever";
        try
        {
            personsReader.Read(filename, persons);
            var result = personsReader.DoSomethingAfterReading();
            result.DoSomethingElse();
        }
        catch (KeyNotFoundException e)
        {
            MessageBox.Show(e.Message);
        }
        finally
        {
            personsReader.CloseIfYouNeedTo();
        }
        DoSomeUnrelatedCodeHere();
    }
