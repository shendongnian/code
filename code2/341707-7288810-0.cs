     private void Form1_Load(object sender, EventArgs e)
        {
     
            if (listId.Items.Count != 0 && listCell.Items.Count != 0)
            {
                for (int a = 0; a < listId.Items.Count; a++)
                {
                    for (int b = 0; b < listCell.Items.Count; b++)
                    {
                        lblID.Text = listId.Items[a].ToString();
                        MakeReq(listId.Items[a].ToString(), listCell.Items[b].ToString());
                        
                    }
                }
            }            
        }
        public void MakeReq(string listId, string cellId)
        {
            Console.WriteLine("store.domain.com/" + listId + "sec01&ire=" + cellId);
        }
        
