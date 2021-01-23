        foreach (string itemInList in lstBox.Items)
        {
            value = decimal.Parse(itemInList.Substring(50, 2));
            total += (value);
        }
        adverage = (total) / lstBox.Items.Count;
        lblAdverage.Text = Convert.ToString(adverage);
