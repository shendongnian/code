       string skills="";
       for(int i=0;i<chkboxlist.Items.Count;i++)
       {
           if(chkboxlist.Items[i].Selected)
           {
               skills=skills+chkboxlist.Items[i].Text+",";
           }
       }
       skills = skills.Remove(skills.Length-1);
       lblResult.Text = skills.ToString();
    
