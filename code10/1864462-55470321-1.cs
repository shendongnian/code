    string[] ReadMeArry = { "<description>", "DE",  "", "EN",  "</description>", "", "<internal>", "Owner: " + textBox3.Text, "Ticket: " + textBox4.Text, "</internal>" };
    
    var res = ReadMeArry
    .Concat(richTextBox1.Lines)
    .Concat(richTextBox2.Lines).ToArray();
    
    File.WriteAllLines(Path.Combine(path, "ReadMe.txt"), res);
