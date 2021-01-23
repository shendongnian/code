    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       if (listBox1.SelectedIndices.Count > 1)
          {
             List<int> MyCase = new List<int> { 0, 1 };
             if (CasesFunction(listBox1, MyCase))
                label1.Text = "Sometext";
             else
                label1.Text = "";
             MyCase = new List<int> { 1, 2 }; // can do other checks
             if (CasesFunction(listBox1, MyCase))
                label1.Text = "Sometext 2";
             else
                label1.Text = "";
          }
          else
             label1.Text = listBox1.SelectedIndex.ToString();
    }
