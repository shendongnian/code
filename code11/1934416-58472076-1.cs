     private void button1_Click(object sender, EventArgs e)
     {
         listBox2.Items.Clear();
         ArrayList namelist = new ArrayList();
         foreach (object o in listBox1.Items)
         {
             namelist.Add(o);
         }
         namelist.Sort();
         string newItem = "";
         for (int i = 0; i < namelist.Count; i++)
         {
             string item = namelist[i].ToString();
                
             string firstName = item.Substring(0, item.IndexOf(','));
             string initials = item.Substring(item.IndexOf(',')+1);
             initials = initials.Trim();
             //newItem +=  initials;
             if (i + 1 < namelist.Count)
             {
                 string nextItem = namelist[i+1].ToString();
                 string nextFirstName = nextItem.Substring(0, nextItem.IndexOf(','));
                 string nextInitials = nextItem.Substring(nextItem.IndexOf(',') + 1);
                 if(firstName.ToLower() == nextFirstName.ToLower())
                 {
                     newItem += ", " + initials;
                 }
                 else
                 {
                     newItem = firstName + newItem + ", " + initials;
                     listBox2.Items.Add(newItem);
                     newItem = "";
                 }
             }
             else
             {
                 newItem = firstName + newItem + ", " + initials;
                 listBox2.Items.Add(newItem);
                 newItem = "";
             }
         }
     }
