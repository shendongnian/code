            listView.ColumnWidthChanging += (e, sender) =>
            {
                ColumnWidthChangingEventArgs arg = (ColumnWidthChangingEventArgs)sender;
                arg.Cancel = true;
                arg.NewWidth = lvAdSchedule.Columns[arg.ColumnIndex].Width;
            };
