    int num;
    private void CmdAdd_Click(object sender, EventArgs e)
    {    
        num ++;
        LblNum.Text = (Convert.ToString(num));
        //Pass the filepath and filename to the StreamWriter Constructor
        StreamWriter sw = new StreamWriter("C:\\Test.txt");
        //Write a line of text
        sw.WriteLine(LblNum.Text);
        //Close the file
        sw.Close();
    }
