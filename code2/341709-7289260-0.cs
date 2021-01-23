        if (listId.Items.Count != 0 && listCell.Items.Count != 0)
        {
            for (int a = 0; a < listId.Items.Count; a++)
            {
                int listCellCount = listCell.Items.Count;
                for (int b = 0; b < listCell.Items.Count; b++)
                {
                    lblID.Text = listId.Items[a].ToString();
                    MakeReq(txtWebUpdate.Text + listId.Items[a].ToString() + 
                        "&ire=1", listCell.Items[b].ToString());
                    //System.Threading.Thread.Sleep(5);
                    Debug.Assert(listCellCount == listCell.Items.Count);
                }
            }
        }
