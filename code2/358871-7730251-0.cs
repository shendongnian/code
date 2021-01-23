    public class Form1:Form
    {
       public event EventHandler<MyDataObject> DataChanged;
    
       ...
    
       public override void OnClosing(CancelEventArgs e)
       {
          //Put in logic to determine whether we should fire the DataChanged event
          try
          {
             if(DataChanged != null) DataChanged(this, myFormCurrentData);
             base.OnClosing(e);
          }
          catch(Exception ex)
          {
             //If any handlers failed, cancel closing the window until the errors
             //are resolved.
             MessageBox.Show(ex.Message, "Error While Saving", MessageBoxButtons.OK);
             e.Cancel = true;
          }
       }
    }
    
    ...
    
    public class Form2:Form
    {
       //Called from wherever you would open Form1 from Form2
       public void LaunchForm1()
       {
          var form1 = new Form1();
          form1.DataChanged += HandleDataChange;
          form1.Show();
       }
    
       private void HandleDataChange(object sender, MyDataObject dataObj)
       {
          //Do your data validation or persistence in this method; if it fails,
          //throw a descriptive exception, which will prevent Form1 from closing.
       }
    }
