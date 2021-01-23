	public class TransparentRadioElement : RadioElement {
		public TransparentRadioElement (string caption, string group) : base (caption, group)
		{
		}
				
		public TransparentRadioElement (string caption) : base (caption)
		{
		}
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = base.GetCell (tv);
			cell.BackgroundColor = UIColor.Clear;
			return cell;
		}
	}
