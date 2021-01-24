    public static void CreateWordDocument()
    {
        //How to save the above Console.Writeline in the word file??
        string filePath = @"C:\temp\newdoc.doc";
        _Application word = new Application();
        var doc = word.Documents.Add(); 
        var para = doc.Paragraphs.Add();
        para.Range.Text = string.Empty;
            
        void printer(string message, WdColor color = WdColor.wdColorBlack, WdColor background = WdColor.wdColorWhite, bool newLine = true)
        {
            if (newLine)
            {
                para.Range.InsertAfter(message + Environment.NewLine);
                para.Range.Font.Color = color;
                para.Range.Shading.BackgroundPatternColor = background;
                Console.WriteLine(message);
            }
            else
            {
                para.Range.InsertAfter(message);
                Console.Write(message);
            }
        }
        int p, lastInt = 0, input;
        printer("Enter the Number of Rows : ", WdColor.wdColorDarkTeal, newLine: false);
        input = int.Parse(Console.ReadLine());
        printer(input.ToString(), WdColor.wdColorGreen);
        for (int i = 1; i <= input; i++)
        {
            for (p = 1; p <= i; p++)
            {
                if (lastInt == 1)
                {
                    printer("0", newLine:false);
                    lastInt = 0;
                }
                else if (lastInt == 0)
                {
                    printer("1", newLine: false);
                    lastInt = 1;
                }
                    
            }
            printer(Environment.NewLine, WdColor.wdColorLightOrange);
        }
        doc.SaveAs2(filePath);
        doc.Close();
    }
I would strongly recommend reading up on how to manipulate data within Word document but this should give you a good idea on how to save what you are trying to print to console. Anything you are printing to Console with Console.WriteLine() cannot be redirected to write to word document within the c# code.
