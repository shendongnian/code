           DataGridViewLinkColumn links = new DataGridViewLinkColumn();
            links.HeaderText = "Hello";
            links.UseColumnTextForLinkValue = true;
            links.Text="http://microsoft.com";
            links.ActiveLinkColor = Color.White;
            links.LinkBehavior = LinkBehavior.SystemDefault;
            links.LinkColor = Color.Blue;
            links.TrackVisitedState = true;
            links.VisitedLinkColor = Color.YellowGreen;
            dataGridView.Columns.Add(links);
