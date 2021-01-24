c#
// Simple GridView control
DataGridView gridView = new System.Windows.Forms.DataGridView();
gridView.Columns.Add("A", "A");
gridView.Columns.Add("B", "B");
gridView.Columns.Add("C", "C");
// Display the Control in LINQPad
PanelManager.DisplayControl(gridView);
await Task.Run(async () => 
{
	while(true)
	{
		// your listener code		
		var results = Enumerable.Range(0, 100).Select(x => x).ToList();
		
		if(gridView.IsHandleCreated)
		{
			// render on the UI thread
			gridView.Invoke((MethodInvoker)delegate
			{
				for (int i = 0; i < results.Count; i++)
				{
					int index = gridView.Rows.Add();
					gridView.Rows[index].Cells[0].Value = 1;
					gridView.Rows[index].Cells[1].Value = 2;
					gridView.Rows[index].Cells[2].Value = 3;
				}
			});
		}
		await Task.Delay(1000); // remove this from your solution, your listener is blocking
	}
});
