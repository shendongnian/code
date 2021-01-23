    private void button1_Click(object sender, EventArgs e)
    {
        Action<string> method = loop;
        method.BeginInvoke(str, null, null);
    }
    
    private void loop(string str)
    {
        for (int i = 0; i < 100000; i++)
        {
            //textBox1.Text = i + str;
            UpdateTextBoxText(textBox1, i+str);
        }
    }
    private void UpdateTextBoxText(TextBox textBox, string text)
    {
       //the method will invoke itself on the main thread if it isn't already running there
       if(InvokeRequired)
       {
          this.Invoke((MethodInvoker)(()=>UpdateTextBoxText(textBox, text)));
          return;
       }
      
       textBox.Text = text;
    }
