	public class MyComboBox : ComboBox
	{
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			var index = e.KeyChar - '1';
			if( index >= 0 && index < this.Items.Count )
				this.SelectedIndex = index;
			base.OnKeyPress(e);
		}
	}
