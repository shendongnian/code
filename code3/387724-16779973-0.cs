    public void SetValueAndUpdate(string caption) {
    	this.Caption = caption;
    	if (this.cell != null) {
    	   this.PrepareCell (cell);
        };
    }
    
    public override UITableViewCell GetCell (UITableView tv)
		{
			this.cell = base.GetCell (tv);
			if (!this.HighlightOnTap)
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			return cell;
		}			
