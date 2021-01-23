    List<TestObject> _list = new List<TestObject>();
		public Form1()
		{
			InitializeComponent();
			dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
		}
		void dataGridView1_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
		{
			
		}
		private void Form1_Load( object sender, EventArgs e )
		{
			// Populate the grid, here you should add as many rows as you want to display
			_list.Add(new TestObject("Obj1", 20, Brushes.Red, new int[]{3,4,5,3,5,6}));
			_list.Add(new TestObject("Obj2", 10, Brushes.Green, new int[] { 1, 2, 3, 4, 5, 6 }));
			_list.Add(new TestObject("Obj3", 30, Brushes.Blue, new int[] { 3, 2, 1, 1, 2, 3 }));
			dataGridView1.DataSource = _list;
			
		}
