    StringBuilder sb = new StringBuilder();
    void printer(string message, bool newLine = true) 
    { 
        if (newLine) 
        {
            sb.AppendLine(message); 
            Console.WriteLine(message); 
        }
        else 
        {
            sb.Append(message); 
            Console.Write(message); 
        } 
    }
    string filePath = @"C:\temp\newdoc.doc";
    _Application word = new Application();
    var doc = word.Documents.Add();
    int p, lastInt = 0, input;
    printer("Enter the Number of Rows : ", false);
    input = int.Parse(Console.ReadLine());
    printer(input.ToString());
    for (int i = 1; i <= input; i++)
    {
        for (p = 1; p <= i; p++)
        {
            if (lastInt == 1)
            {
                printer("0", false);
                lastInt = 0;
            }
            else if (lastInt == 0)
            {
                printer("1", false);
                lastInt = 1;
            }
        }
        printer("\n");
    }
    printer("");
    //How to save the above Console.Writeline in the word file??
    var para = doc.Paragraphs.Add();
    para.Range.Text = sb.ToString();
    doc.SaveAs2(filePath);
    doc.Close();
