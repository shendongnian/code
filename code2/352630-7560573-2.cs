    public string GetItemValue()
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Checked == true)
                    {
                        return listView1.Items[i].Text; // I want to keep this value
                    }
                }
                throw new InvalidOperationException("Did not find value expected.");
            }
