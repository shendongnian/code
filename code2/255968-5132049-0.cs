    using (StreamReader sr = new StreamReader(@"saved.txt"))
    {
        string[] inputData = sr.ReadToEnd().Split(new string[] { "\n","\r","\n\r" }, 
            StringSplitOptions.RemoveEmptyEntries);
        var textboxes = (from Control textbox in this.Controls
                            where textbox is TextBox
                            select textbox).ToArray();
        for (int i = 0; i < textboxes.Count(); i++)
        {
            textboxes[i].Text = inputData[i];
        }
    }
