    public static void colorListcolor(ListView lsvMain)
        {           
           
            foreach (ListViewItem lvw in lsvMain.Items)
            {
                lvw.UseItemStyleForSubItems = false;
                for (int i = 0; i < lsvMain.Columns.Count; i++)
                {
                    if (lvw.SubItems[i].Text.ToString() == "Monday")
                    {
                        lvw.SubItems[i].BackColor = Color.Red;
                        lvw.SubItems[i].ForeColor = Color.White;
                    }
                    else {
                        lvw.SubItems[i].BackColor = Color.White;
                        lvw.SubItems[i].ForeColor = Color.Black; 
                    }
                }
     
            }      
        }[![Screenshot of the result from the code above][1]][1]
