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
      // as for grids, this will ALSO result in never releasing the form in memory, because the GridControl has a reference to the Form itself (look at the auto-generated designer code)
      var form3 = new MyForm();
      form3.ShowDialog();
      var grid = form3.MyGrid;
      // note that if you're planning on actually using your datagrid after calling dispose on the form, you're going to have problems, since calling Dipose() on the form will also call dispose on all the child controls
      form3.Dispose();
      form3 = null;
    }
