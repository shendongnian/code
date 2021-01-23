    namespace ViewModel
    {
        [POCOViewModel]
        public class Table2DViewModel
        {
            public ITable2DView Table2DView { get; set; }
    
            public DataTable ItemsTable { get; set; }
    
    
            public Table2DViewModel()
            {
            }
    
            public Table2DViewModel(MainViewModel mainViewModel, ITable2DView table2DView) : base(mainViewModel)
            {
                Table2DView = table2DView;   
                CreateTable();
            }
    
            private void CreateTable()
            {
                var dt = new DataTable();
                var xAxisStrings = new string[]{"X1","X2","X3"};
                var yAxisStrings = new string[]{"Y1","Y2","Y3"};
                //TODO determine your min, max number for your colours
                var minValue = 0;
                var maxValue = 100;
                Table2DView.SetColorFormatter(minValue,maxValue, null);
    
                //Add the columns
                dt.Columns.Add(" ", typeof(string));
                foreach (var x in xAxisStrings) dt.Columns.Add(x, typeof(double));
    
                //Add all the values
    			double z = 0;
                for (var y = 0; y < yAxisStrings.Length; y++)
                {
                    var dr = dt.NewRow();
                    dr[" "] = yAxisStrings[y];
                    for (var x = 0; x < xAxisStrings.Length; x++)
                    {
    				    //TODO put your actual values here!
                        dr[xAxisStrings[x]] = z++; //Add a random values
                    }
                    dt.Rows.Add(dr);
                }
                ItemsTable = dt;
            }
    
    
            public static Table2DViewModel Create(MainViewModel mainViewModel, ITable2DView table2DView)
            {
                var factory = ViewModelSource.Factory((MainViewModel mainVm, ITable2DView view) => new Table2DViewModel(mainVm, view));
                return factory(mainViewModel, table2DView);
            }
        }
        
    }
