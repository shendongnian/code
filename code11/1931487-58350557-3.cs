        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell;
            // try to get a reusable cell
            cell = tableView.DequeueReusableCell("countries");
            if (cell == null)
            {
                cell = new UITableViewCell( UITableViewCellStyle.Subtitle, "countries");
            }
            
             // Get data for row
             string countryName = countries[indexPath.Row];
             // Display data in the cell
             cell.TextLabel.Text = countryName;
             return cell;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            // return the number of items you need to display
            return countries.Count;
        }
