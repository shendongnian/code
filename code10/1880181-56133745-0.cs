	private void UncheckAll(CheckedListBox clb)
	{
		if (clb.InvokeRequired)
		{
			clb.Invoke((MethodInvoker)delegate {
				UncheckAll(clb);
			});
		}
		else
		{
			for(int i = 0; i < clb.Items.Count; i++)
			{
				if (clb.GetItemChecked(i))
				{
					clb.SetItemChecked(i, false);
				}
			}                
		}
	}
