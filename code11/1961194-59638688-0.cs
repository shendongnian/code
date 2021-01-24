    public class myEntryCelliOSCellRenderer : EntryCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var nativeCell = (EntryCell)item;
            var cell = base.GetCell(nativeCell, reusableCell, tv);
            ((UITextField)cell.Subviews[0].Subviews[0]).TextColor = UIColor.Orange;
            ((UITextField)cell.Subviews[0].Subviews[0]).BackgroundColor = UIColor.Green;
            //Change the entrycell backgroundColor
            cell.ContentView.BackgroundColor = UIColor.Red;
            return cell;
        }
    }
