    public Form1()
    {
        InitializeComponent();
        // Could add calls here
        LoadData();
        RunExcel();
    }
    // Remove this button click handler if desired
    private void button1_Click(object sender, EventArgs e)
    {
       LoadData();
    }
    // Remove this button click handler if desired
    private void button2_Click(object sender, EventArgs e)
    {
       RunExcel();
    }
    private void LoadData()
    {
        string[] fileEntries = Directory.GetFiles(@"c:\Sciclone UAC", "*.cfg*");
        foreach (string fileName in fileEntries)
        {
            var query = from file in fileEntries
                        let doc = XDocument.Load(file)
                        let x = doc.Descendants("XAxisCalib").Single()
                        let y = doc.Descendants("YAxisCalib").Single()
                        let z = doc.Descendants("ZAxisCalib").Single()
                        select new
                        {
                            XMax = x.Element("Max").Value,
                            XMin = x.Element("Min").Value,
                            YMax = y.Element("Max").Value,
                            YMin = y.Element("Min").Value,
                            ZMax = z.Element("Max").Value,
                            ZMin = z.Element("Min").Value
                        }; 
            var bs3 = new BindingSource { DataSource = query };
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bs3;
        }
    }
    private void RunExcel()
    {
       Excel.Application xlApp ;
       Excel.Workbook xlWorkBook ;
       Excel.Worksheet xlWorkSheet ;
       object misValue = System.Reflection.Missing.Value;
       xlApp = new Excel.Application();
       xlWorkBook = xlApp.Workbooks.Add(misValue);
       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
       ....
    }
