    MarketCell cell = tableView.DequeueReusableCell(_cellIdentifier) as MarketCell;
    if (cell == null) {
      cell = new MarketCell(UITableViewCellStyle.Subtitle, _cellIdentifier);
    }
    
    // Assign the correct item
    cell.Item = item;
    // or (whatever you like more):
    // cell.SetItem(item);
    // Decorate the cell
    // ...
    return cell;
