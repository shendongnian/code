            FileStream fs = new FileStream(@"C:\Users\dejv2\Desktop\Program Test\Docházka\David 
    Cáder"+ "Docházka David Cáder.txt", FileMode.Append, FileAccess.Write);
            StreamWriter dc = new StreamWriter(fs);
            if (textBox1.Text == "David Cáder")
    {
        dc.WriteLine(dateTimePicker1.Text + " - David Cáder - " + 
    textBox56.Text);
    
        }
            dc.Close();
            fs.Close();
