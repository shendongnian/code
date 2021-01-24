	private void OnResult(object sender, ResultEventArgs e)
	{
		Action x = () =>
		{
			using (var form = new SecondForm(e))
			{
				var dialogResult = form.ShowDialog(this);
				if (dialogResult == DialogResult.Cancel)
					return;
			}
		};
		
		this.Invoke(x);
	}
