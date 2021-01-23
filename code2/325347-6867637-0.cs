            //note that this will just save it in the bin folder
            //you'll want to use a better path
            string settingsFile = "GridSettings.xml";
            DataTable gridData = null;
    
            public FormSaveFoo()
            {
                InitializeComponent();
                PrepareSettingsDataSource();
                SetUpDataSourceBindings();
    
            }
    
            private void PrepareSettingsDataSource()
            {
                //see if have a settings file
                if (File.Exists(settingsFile))
                {
                    //load up the settings 
                    DataSet settings = new DataSet();
                    settings.ReadXml(settingsFile);
                    if (settings.Tables.Count > 0)
                    {
                        gridData = settings.Tables[0];
                    }
                }
                else
                {
                    CreateSettingsTable();
                }
            }
    
            private void CreateSettingsTable()
            {
                gridData = new DataTable();
                gridData.Columns.Add(new DataColumn("Name"));
                gridData.Columns.Add(new DataColumn("Text"));
            }
    
            private void SetUpDataSourceBindings()
            {
               
                dataGridView1.Columns["NameColumn1"].DataPropertyName = "Name";
                dataGridView1.Columns["TextColumn1"].DataPropertyName = "Text";
                dataGridView1.DataSource = gridData;
            }
    
         
            private void button1_Click(object sender, EventArgs e)
            {
                //add the grid data to a dataset and then write it to a file
                DataSet persistSettings = new DataSet();
                persistSettings.Tables.Add(gridData);
                persistSettings.WriteXml(settingsFile);
            }
