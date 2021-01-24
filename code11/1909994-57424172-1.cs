        string content = string.Empty;
        using (StreamReader sr = new StreamReader(@"C:\Users\dejv2\Desktop\Program Test\Docházka\DavidCáder" + "Docházka David Cáder.txt"))
        {
            content = sr.ReadToEnd();
        }
        using (StreamWriter dc = new StreamWriter(@"C:\Users\dejv2\Desktop\Program Test\Docházka\DavidCáder" + "Docházka David Cáder.txt"))
        {
            dc.WriteLine(content);
            if (textBox1.Text == "David Cáder")
            {
                dc.WriteLine(dateTimePicker1.Text + " - David Cáder - " + textBox56.Text);
            }
        }
