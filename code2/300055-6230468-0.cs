    private void button6_Click(object sender, EventArgs e)
    {
        richTextBox4.Text = 
            Directory.GetFiles(@"C:\MyDir\")
                     .Aggregate("", (text, pathName) => 
                         text += String.Format("{0}\n", pathName))
                      );
    }
