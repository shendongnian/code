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
          for (int i = 0; i < lv.Items.Count; i++)
          {
            // is i the index of the row you selected?
            if (lv.Items[i].Selected == true)
            {  
              //I show here the second field text (SubItems[1].Text) from the selected row(Items[i]) 
                    Message.Show(lv.Items[i].SubItems[1].Text);
                    break;
            }            
          }
          Form2 frm2 = new Form2();
          frm2.Name= text1;
          frm2.phonenumber = text2;
          frm2.Show();
          this.Hide();  //// if you want to hide the form1
        }
      }
    }
