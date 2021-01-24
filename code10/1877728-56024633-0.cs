	void Main()
	{
		var data = new[] {
			new MyData { Id = 1, Typ = "Prichozi", Castka =  500, Datum = new DateTime(2019, 4, 16), Ucel = "test" },
			new MyData { Id = 2, Typ = "Odchozi",  Castka =  250, Datum = new DateTime(2019, 4, 16), Ucel = "test" },
			new MyData { Id = 3, Typ = "Prichozi", Castka = 2000, Datum = new DateTime(2019, 4, 16), Ucel = "test" },
			new MyData { Id = 4, Typ = "Odchozi",  Castka = 3500, Datum = new DateTime(2019, 4, 16), Ucel = "test" },
			new MyData { Id = 5, Typ = "Prichozi", Castka = 5000, Datum = new DateTime(2019, 4, 16), Ucel = "test" }
		};
	
		var view = new DataGridView();
		view.AllowUserToAddRows = false;
		view.AllowUserToDeleteRows = false;
		view.AllowUserToResizeRows = false;
		view.Anchor = System.Windows.Forms.AnchorStyles.Top
			| System.Windows.Forms.AnchorStyles.Bottom 
			| System.Windows.Forms.AnchorStyles.Left 
			| System.Windows.Forms.AnchorStyles.Right;
		view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		view.ReadOnly = true;
		view.RowHeadersVisible = false;
		view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		view.Dock = System.Windows.Forms.DockStyle.Fill;
		view.MouseClick += (sender, args) => { 
			// This is where the magic happens
			var selectedObject = ((DataGridView)sender)
				.SelectedRows.Cast<DataGridViewRow>()
				.Select(dgvr => dgvr.DataBoundItem).Cast<MyData>()
				.FirstOrDefault();
			// Show your result
			MessageBox.Show(
				$"Selected row with ID: {selectedObject.Id}",
				"Selection Notification", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly,
				false);
			};
		view.DataSource = data;
	
		var form = new Form { Width = 500, Height = 300 };
		form.Controls.Add(view);
		form.ShowDialog();
	}
	
	public class MyData
	{
		public int Id { get; set; }
		public string Typ { get; set; }
		public int Castka { get; set; }
		public DateTime Datum { get; set; }
		public string Ucel { get; set; }
	}
