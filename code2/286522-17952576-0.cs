	// http://www.csharpbydesign.com/2009/07/linqbugging---using-linqpad-for-winforms-testing.html
	void Main()
	{
		var context = this;
		using (var form = new Form())
		{
			var dgv = new DataGridView();
			var binder = new BindingSource();
			
			// All of the following variations work
	//		var efCollection = context.NOS_MDT_PROJECT;
	//		var sortableCollection = new BindingListView<NOS_MDT_PROJECT>(
	//			efCollection.ToList());
	//		var efCollection = context.NOS_MDT_PROJECT.First()
	//			.NOS_DEFL_TEST_SECT;
	//		var sortableCollection = new BindingListView<NOS_DEFL_TEST_SECT>(
	//			efCollection.ToList());
			var efCollection = 
				from p in context.NOS_MDT_PROJECT
				where p.NMP_ID==365
				from s in p.NOS_GPR_TST_SECT_COMN_DATA
				from l in s.NOS_GPR_TST_LOC_DATA
				select l;
			var sortableCollection = new BindingListView<NOS_GPR_TST_LOC_DATA>(
				efCollection.ToList());
			
			binder.DataSource = sortableCollection;
			dgv.DataSource = binder;
			
			dgv.Dock = DockStyle.Fill;
			form.Controls.Add(dgv);
			form.Shown += (o, e) => {
				dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			};
			form.ShowInTaskbar=true;
			form.ShowDialog();
			if (context.IsDirty()) // Extension method
			{
				if (DialogResult.Yes == MessageBox.Show("Save changes?", "", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
				{
					context.SaveChanges();
				}
			}
		}
	}
