     using System.Linq;
     ... 
     //TODO: Main is a specific name (entry point of the exe), I suggest renaming it
     private static void Main() {
        // Do we have opened Form1? 
        Form1 form = Application
          .OpenForms        // from all opened forms
          .OfType<Form1>()  // we want just Form1 instances
          .LastOrDefault(); // If we have several, let's take the last one
        
        // Comment out this fragment if you don't want to create it
        if (null == form) { 
          // No open Form1 forms found
          form = new Form1(); // Let's create Form1 instance manually
          form.Show();        // And Show it
        }
        else {
          // form has been found; but you may want
          // Resore it if it's minimized 
          if (form.WindowState == FormWindowState.Minimized)
            form.WindowState = FormWindowState.Normal;
          // Bring it to front
          form.BringToFront();
          // Set keyboard focus on it 
          if (form.CanFocus)
            form.Focus(); 
        }
        // We have a form to work with, we are ready to call the method
        if (null != form)
          form.WriteLine("Hello World!");  
        else { // No Form1 intance has been found; we can't call WriteLine
          //TODO: put relevant code here
        }             
     }
   
