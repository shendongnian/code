    string myData = txtMyTextBox.Text.Replace("\r"," \\r ").Replace("\n"," \\n ");
    using(System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath))
    {
         sw.Write(myData);
    }
