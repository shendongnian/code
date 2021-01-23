        private GridView SetUpGrid()
        {
            GridView GView = new GridView();
            GView .ColumnHeaderToolTip = "MyToolTip";
            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("Col1Name");
            gvc1.Header = "Column One";
            gvc1.Width = Double.NaN; // Auto-Size
            GView .Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("Col2Name");
            gvc2.Header = "Column Two";
            gvc2.Width = Double.NaN;
            GView .Columns.Add(gvc2);
            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("Col3Name");
            gvc3.Header = "Column Three";
            gvc3.Width = Double.NaN;
            GView .Columns.Add(gvc3);
            GridViewColumn gvc4 = new GridViewColumn();
            gvc4.DisplayMemberBinding = new Binding("Col4Name");
            gvc4.Header = "Column Four";
            gvc4.Width = Double.NaN;
            GView .Columns.Add(gvc4);
            return GView;
        }
