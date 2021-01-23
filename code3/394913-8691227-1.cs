    private bool save_check()  
            {
                for (int i = 0; i < listView1.Items.Count; i++)  
                {                
                    string text = listView1.Items[i].Text;  
                    for (int i = 0; i < listView2.Items.Count; i++)  
                    {  
                        if (listView2.Items[i].Text.Equals(text))  
                        {                              
                            return False;  
                        }  
                    }  
                }  
                 return True;
            }
