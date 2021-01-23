    delegate void myDelegate(string name);
    //...
    private void writeToTextbox(string fCounter)
            {
                if (this.InvokeRequired)
                {
                    myDelegate textWriter = new myDelegate(displayFNums);
                    this.Invoke(textWriter, new object[] { fCounter });
                }
                else
                {
                    textbox1.Text = "Processing file: " + fileCounter + "of" + 100;
                }
            }
    //...
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        //...
        writeToTextbox(fileCounter.ToString());
    }
