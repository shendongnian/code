    private void FillListBox(SortingRepresentation sortcriterion)
    {
        this.lstClient.Items.Clear();
        List<Client> sortedList = sortcriterion.Field == SortField.All ? this.client.ToList() 
                : this.client.Where(x => x.GetType() == sortcriterion.TypeCriterion).ToList();
        
        foreach (Client c in sortedList)
        {
            this.lstClient.Items.Add(c.ToString());
        }
        this.lstClient.Sorted = true;
    }
