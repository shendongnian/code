        // Properties or Product Type Cell
        if (indexPath.Section <= SelectedProduct.Types.Count)
        {
            cellIdentifier = new NSString("propertiesCell"); 
            var cell = tableView.DequeueReusableCell(cellIdentifier) as ProductPropertiesCell;
            cell.UpdatePicker (this, SelectedProduct.Types [indexPath.Section - SelectedProduct.Props.Count - 1], indexPath);
            //Edit mode -> add selected value
            if (Parent.Edit)
                cell.ValuePicked = Parent.Info.SavedProductInstace[indexPath.Section];
            return cell;
        }
