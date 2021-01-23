	public class TransparentRootElement : RootElement {
		// add required .ctors
     
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = base.GetCell (tv);
			cell.BackgroundColor = UIColor.Clear;
			return cell;
		}
	}
