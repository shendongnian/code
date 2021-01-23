    private void Populatedropdown()
    {
        if(this.Items.Count == 0)
        {
          this.Items.Clear();
          this.Items.Add(new ListItem("Alabama", "AL"));
          /* the rest .... */
          this.Items.Add(new ListItem("Wyoming", "WY"));
        }
    }
