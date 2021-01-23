    class OkPressedEventArgs : EventArgs
    {
       public OkPressedEventArgs(string text1, string text2, string text3)
       {
          Text1 = text1;
          Text2 = text2;
          Text3 = text3;
       }
    
       public string Text1 {get;private set;}
       public string Text2 {get;private set;}
       public string Text3 {get;private set;}
    }
    
    class SourceForm : Form
    {
       public event EventHandler<OkPressedEventArgs> OkPressed;
       private void OnOkPressed()
       {
          if(OkPressed != null)
          {
              OkPressed(this, new OkPressedEventArgs(textBox1.Text, textBox2.Text, textBox2.Text);
          } 
       }
    
       private void okButton_Click(object source, EventArgs e)
       {
           OnOkPressed();
       }
    }
    
    class TargetClass
    {
       void ShowFormMethod()
       {
          var form = new SourceForm();
          form.OkPressed += OkPressedHandler;
          form.Show();
       }
    
       private void OkPressedHandler(object source, OkPressedEventArgs e)
       {
          // process form data here!
       }
    }
