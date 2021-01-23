   private List<object> gotRefs = new List<object>();
   public void MyMethod()
   {
      if (!gotRefs.Contains(txtTextBox1)) {
        txtTextBox1.TextChanged += txtTextBox1_TextChanged;
        gotRefs.Add(txtTextBox1);
      }
   }
