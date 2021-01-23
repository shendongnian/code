       Image imgSortUp;
       Image imgSortDown;
       if (cp.Content.ToString() == "Work Order #" || cp.Content.ToString() == "Status")
        {
            imgSortUp = (sender as Grid).GetVisualDescendants().OfType<Image>().Where(i => i.Name == "SortIconUp").SingleOrDefault();
            imgSortDown = (sender as Grid).GetVisualDescendants().OfType<Image>().Where(i => i.Name == "SortIconDown").SingleOrDefault();
        }
        else
            return;
