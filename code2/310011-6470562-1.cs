    template1 = (DataTemplate)FindName("someTemplate");
            linkColumn1 = new GridViewColumn
            {
                Header = "Test",
                CellTemplate = template1,
                //Width = 88,  // Comment out to set to auto
            };
            gv.Columns.Add(linkColumn1);
