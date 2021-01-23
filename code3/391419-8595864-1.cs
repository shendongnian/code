    public class Form1
    {
        private DataGridView dgv { get; set; }
        private void LoadMyData()
        {
            dgv.DataSource = GlobalDataSources.SomeDataSource;
        }
        private void DoSomething()
        {
            var anotherForm = new Form2();
            anotherForm.DoSomethingElse();
        }
    }
    public class Form2
    {
        public void DoSomethingElse()
        {
            var data = GlobalDataSources.SomeDataSource;
        }
    }
    public class GlobalDataSources
    {
        private static SomeDataSourceType _someDataSource;
        public static SomeDataSourceType SomeDataSource
        {
            get
            {
                if (_someDataSource == null)
                {
                    // populate the data source
                }
                return _someDataSource;
            }
        }
    }
