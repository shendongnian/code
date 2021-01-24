    public void WriteToAIFile(string findThis, string writeThis)
    {
        var fileContent = File.ReadAllLines(@"LogicFiles\rj-ai-fields.txt");
        using (var output = File.CreateText("My filename"))
        {
            for (int i = 1; i < fileContent.Length; ++i)
            {
                if (fileContent[i] == findThis)
                    output.WriteLine(fileContent[i-1] + "|" + writeThis);
                else
                    output.WriteLine(fileContent[i-1]);
            }
            output.WriteLine(fileContent[fileContent.Length-1]);
        }
    }
