    public void UpdateCaption(string caption) {
			this.Caption = caption;
			Console.WriteLine ("actualizando : " + Caption);
			UITableViewCell cell = this.GetActiveCell ();
			if (cell != null) {
				this.PrepareCell (cell);
				cell.SetNeedsLayout ();
			}
    }
			
