    private void listView1_SelectedIndexChanged(object sender, EventArgs e)  
            {  
                if (listView1.SelectedItems.Count > 0)  
                {  
                    string text = listView1.SelectedItems[0].Text;  
                    for (int i = 0; i < listView2.Items.Count; i++)  
                    {  
                        if (listView2.Items[i].Text.Equals(text))  
                        {  
                            listView2.Items[i].Remove();  
                            return;  
                        }  
                    }  
                }  
            }
