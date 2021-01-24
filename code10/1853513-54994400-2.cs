    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        bool is1To4Selected =  false;
        for (int i=0; i < CheckBoxList1.Items.Count; i++)
        {
          if (CheckBoxList1.Items[i].Selected  && CheckBoxList1.Items[i].Value == "5")
          {
            return false;
          } else if(CheckBoxList1.Items[i].Selected) 
          {
            is1To4Selected = true;
          }
       }
    
       if(is1To4Selected)
       {
         Results.Text += " <br> Question 4 is Correct. <br>";
       } else {
          Results.Text += " Question 4 is Incorrect. <br>";
       }
    }
