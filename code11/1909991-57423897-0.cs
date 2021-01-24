    StreamWriter dc = new StreamWriter(@"C:\Users\dejv2\Desktop\Program Test\Docházka\David 
    Cáder"+ "Docházka David Cáder.txt");
    StreamReader sr = new StreamReader(@"C:\Users\dejv2\Desktop\Program Test\Docházka\David 
    Cáder"+ "Docházka David Cáder.txt");
    string str = sr.ReadToEnd();
    dc.WriteLine(str);
    if (textBox1.Text == "David Cáder")
    {
        dc.WriteLine(dateTimePicker1.Text + " - David Cáder - " + 
    textBox56.Text);
        }
