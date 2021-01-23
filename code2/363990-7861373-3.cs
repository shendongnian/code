    public class Form2
    {
        public string Name
        {
            get { return textbox1.Text; }
            set { textbox1.Text = value; }
        }
        public string phonenumber
        {
            get { return textbox2.Text; }
            set { textbox2.Text = value; }
        }
    
     }
    public class Form1
    {
      private void btnedit_Click(object sender, eventargs e)
      {
        If (listView.SelectedItems.Count > 0) 
        { 
           string text1 = listView.SelectedItems(0).SubItems(1).Text;
           string text2 = listview.SelectedItems(0).SubItems(2).Text;
          Form2 frm2 = new Form2();
          frm2.Name= text1;
          frm2.phonenumber = text2;
          frm2.Show();
          this.Hide();  //// if you want to hide the form1
        }
      }
    }
