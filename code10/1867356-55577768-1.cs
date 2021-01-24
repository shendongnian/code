    public class CharStats
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
    public Form1()
    {
        InitializeComponent();
        // From File:
        // FirstName;LastName;Age
        // d;D;4
        // e;E;5
        using (StreamReader sr = new StreamReader(@"C:\Temp\myfile.csv"))
        {
            using (CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(sr))
            {
                IEnumerable<CharStats> statList = csvReader.GetRecords(typeof(CharStats)).Cast<CharStats>();
                foreach (CharStats cs in statList)
                {
                    this.listBox1.Items.Add(cs);
                }
            }
        }
        this.listBox1.Items.Add(new CharStats() { FirstName = "a", LastName = "A", Age = 1 });
        this.listBox1.Items.Add(new CharStats() { FirstName = "b", LastName = "B", Age = 2 });
        this.listBox1.Items.Add(new CharStats() { FirstName = "c", LastName = "C", Age = 3 });
    
        this.listBox1.SelectedIndex = 1;
    
        var item = this.listBox1.SelectedItem;
    
        CharStats selected = item as CharStats;
    
        if (selected != null)
            MessageBox.Show("Worked. We selected: " + selected.FirstName + " " +     selected.LastName + " (" + selected.Age + ")");
    }
