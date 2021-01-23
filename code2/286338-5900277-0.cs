    public class SubclassHWND : NativeWindow
    {
       protected override void WndProc(ref Message m)
       {
          // Perform whatever custom processing you must have for this message
          System.Diagnostics.Debug.WriteLine(m.ToString());
          // forward message to base WndProc
          base.WndProc(ref m);
       }
    }
    
    SubclassHWND s = new SubclassHWND();
    s.AssignHandle(theWindowHandle);
    //Now s should be listening to the messages of the form.
