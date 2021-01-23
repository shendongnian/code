    private void PlusButtonClick()
    {
        int newIndex = 0;
        for (int x = 0; x < listView1.Items.Count; x++)
        {
            if(listItem.Selected);
            {
                listItem.Selected = false;
                newIndex = x++;
                break;
            }
        }
        this.listView1.Items[newIndex].Selected = true;
    }
