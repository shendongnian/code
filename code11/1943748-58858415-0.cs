    bool flag1=true;
    private void timer3_Tick(object sender, EventArgs e)
    {
        chksignal_robot(); //keep checking signal           
        if (textBox8.Text.Contains("process")   && flag1==true) //
        {
            flag1=false
            totalsheetcount++;
            grab_image();
            Thread.Sleep(200);               
            processimage();  
            flag1=true  
        }
    }
