    for(int i=0; i<list.Count; i++)
    {
        HyperLink link = new HyperLink();
        link.ID = "Feed" + i;
        link.NavigateUrl = "";
        link.Text = list[i].Title;;
        link.Tooltip = list[i].Description;
        baslik1.Controls.Add(link);
    }
