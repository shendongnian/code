    protected override void OnAppearing()
    {
        base.OnAppearing();
        var header = conn.Query<Header>("select * from Header");
        for (int i = 0; i < header.Count; i++)
        {
            Header h = header[i];
            if (Header has no matching Detail rows)
            {
             h.btnColor = Color.Blue;
            }
            else if (your condition)
            {
                h.btnColor = Color.Orange;
            }
            else if (your condition) {
                h.btnColor = Color.Green
            }
            else
            {
                h.btnColor = defaultColor;
            }
        }
        HeaderListView.ItemsSource = header;
    }
