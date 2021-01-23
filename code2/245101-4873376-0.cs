            if (objLstbox == null) 
                return; 
            for (int i = 0; i < objLstbox.Items.Count; i++)          
            //objLstbox.SetSelected(i, !objLstbox.GetSelected(i));
            {
                if (objLstbox.Items[i].Selected == true)
                {
                    objLstbox.Items[i].Selected = false;
                }
                else
                {
                    objLstbox.Items[i].Selected = true;
                }
            }
        } 
        protected void Button1_Click(object sender, EventArgs e)
        {
            InvertSelection(ListBox1); 
            InvertSelection(ListBox2); 
            InvertSelection(ListBox3); 
            
                                        
            }
