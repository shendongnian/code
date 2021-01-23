    private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
    {
        //MessageBox.Show("Output from other process");
        try
        {
            string str = e.Data.ToString();
            sb3.AppendLine(str);
            SetText(str); //or use sb3.ToString if you need the entire thing   
            Console.WriteLine(str);
    
        }
        catch (Exception ex)
        {
             Console.WriteLine("{0} Exception caught.", ex);
    
    
        }
    
    }
