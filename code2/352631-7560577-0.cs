    public string GetItemValue()
        {
            string temp = null;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked == true)
                {
                    temp = listView1.Items[i].Text; // I want to keep this value
                    break;
                }
            }
            return temp; // Without overwriting it with this but the compiler requires me to return a value here
        }
