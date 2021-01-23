    Dictionary<int,MarketCellController> controllers = new Dictionary<int,MarketCellController>();
    
    // ...
    
    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
      UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier);
      MarketCellController cellController;
    
      if (cell == null) {
        cellController = new MarketCellController();
        cell = cellController.Cell;
        controllers.Add(cell.Tag, cellController);
      } else {
        cellController = controllers[cell.Tag];
      }
    
      // Decorate the cell (using Methods of your cellController)
      // ...
      return cell;
    }
