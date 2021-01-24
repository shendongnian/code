    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Product Description
            if (indexPath.Section == 0)
            {
                cellIdentifier = new NSString("descriptionCell"); 
                var cell = tableView.DequeueReusableCell(cellIdentifier) as ProductDescriptionCell;
                if (cell == null)
			    { 
                   cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
                 // Here you can modify UITableViewCell to your custom cell
                 //cell = new ProductDescriptionCell(UITableViewCellStyle.Default, cellIdentifier)
                }
                
                cell.UpdateCell(SelectedProduct);
                return cell;
            }
            // Properties or Product Type Cell
            if (indexPath.Section <= SelectedProduct.Types.Count)
            {
                cellIdentifier = new NSString("propertiesCell"); 
                var cell = tableView.DequeueReusableCell(cellIdentifier) as ProductPropertiesCell;
                if (cell == null)
			    { 
                   cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
                 // Here you can modify UITableViewCell to your custom cell
                 //cell = new ProductPropertiesCell(UITableViewCellStyle.Default, cellIdentifier)
                }
                
                cell.UpdatePicker (this, SelectedProduct.Types [indexPath.Section - SelectedProduct.Props.Count - 1], indexPath);
                cell.Tag = indexPath.Section;
                return cell;
            }
            // Comments
            if (indexPath.Section == SelectedProduct.Types.Count + 1)
            {
                cellIdentifier = new NSString ("commentsCell");
                var cell = tableView.DequeueReusableCell (cellIdentifier) as CommentsCell;
                if (cell == null)
			    { 
                   cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
                 // Here you can modify UITableViewCell to your custom cell
                 //cell = new CommentsCell(UITableViewCellStyle.Default, cellIdentifier)
                }
               
                cell.Setup (tableView, indexPath);
                return cell;
            }
            // Quantity
            else {
                cellIdentifier = new NSString ("quantityCell");
                var cell = tableView.DequeueReusableCell (cellIdentifier) as QuantityCell;
                if (cell == null)
			    { 
                   cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
                // Here you can modify UITableViewCell to your custom cell
                 //cell = new QuantityCell(UITableViewCellStyle.Default, cellIdentifier)
                }
                
                cell.UpdateData (Parent);
                return cell;
            } 
    
        }
