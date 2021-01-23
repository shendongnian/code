    List<string> lst = new List<string>();
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
        CheckBox ck = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBoxATH");
        if (ck != null)
        {
          Label lblUsrE = (Label)GridView1.Rows[i].Cells[7].FindControl("LabelEmail");
          string emadr = lblUsrE.Text.ToString();
          if (ck.Checked == true && !lst.Contains(emadr))
          {
            lst.Add(emadr);
            MailMessage mail = new MailMessage();
            mail.To.Add(emadr.ToString());
            ....
           }
         }
    }
