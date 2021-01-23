    static void Main() {
      var form = new MyForm();
      form.Show();
      form.Close();
      // the GC calls below will do NOTHING, because you still have a reference to the form!
      GC.Collect();  
      GC.WaitForPendingFinalizers();  
      GC.Collect();  
      GC.WaitForPendingFinalizers();
      // another thing to not: calling ShowDialog will NOT get Dispose called on your form when you close it
      var form2 = new MyForm();
      DialogResult r = form2.ShowDialog();
      // you MUST manually call dispose after calling ShowDialog! Otherwise Dispose will never get called.
      form2.Dispose();
    }
