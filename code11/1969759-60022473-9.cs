    List<Items>() selecteditems = new List<Items>();
    private void Enter_Click(object sender, EventArgs e)
    {
        var STOCKDict = STOCK.ToDictionary(x => x.id);
        int id;
        if (!int.TryParse(Disp.Text, out id))
        {
            Disp2.Text = ("Enter number or '00' ");
        }
        else
        {
            if (STOCKDict.ContainsKey(id))
            {
                var item = STOCKDict[id];
                selecteditems.Add(item);
                Disp2.Text = (item.Name);
            }
            else
            {
                Disp2.Text = (id + " is not available");
            }
        }
    }
