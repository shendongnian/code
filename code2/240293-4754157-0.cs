    BuildTreeItem(TreeItem Item, Array Set)  
    {
      Array Smalls;
      Array Larges;
      Median = DetermineMedian(Set);
      Item.Value = Median;
      if(Set.Count() == 1)
        return;  
      for (int i = 0; int i < Set.Count(); i++)
      {
        if(Set[i] < Median)
        {
          Smalls.new(Set[i]);
        }
        if(Set[i] > Median)
        {
          Larges.new(Set[i]);
        }
      }
      Item.Lower = new TreeItem;
      Item.Upper = new TreeItem;
      BuildTreeItem(TreeItem.Lower, Smalls);
      BuildTreeItem(TreeItem.Upper, Larges);
    }
