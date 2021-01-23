    protected void btnSave_Click(object sender, EventArgs e)
     {
       for(int i=0;i<Repeater1.Items.Count;i++)
        {            
            GridView GridView1 = (GridView)Repeater1.Items[i].FindControl("GridView1");
            List<int> CheckBoxList = new List<int>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
             {
                 int courseid = (int)GridView1.DataKeys[i][0];
                 CheckBox checkBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                 if (checkBox.Checked)
                  {
                   CheckBoxList.Add(courseid);
                  }
               }
            }
       }
