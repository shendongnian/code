    public class atsTableInclude
    {
        // keep this to allow user to add row
        public atsTableInclude() { }
        public atsTableInclude(string p, bool u)
        {
            Prefix = p;
            Use = u;
        }
        public string Prefix { get; set; }
        public bool Use { get; set; }
    }
        public Sorting.SortableBindingList<T> FillAtsList<T>(string jsonfile) where T : class
        {
            if (!File.Exists(jsonfile))
            {
                MessageBox.Show(jsonfile, "File not found");
                return null;
            }
            try
            {
                // load json from file
                using (StreamReader r = new StreamReader(jsonfile))
                {
                    string json = r.ReadToEnd();
                    var res = JsonConvert.DeserializeObject<List<T>>(json);
                    return new Sorting.SortableBindingList<T>(res);                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot load json", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        private void frmATS_Load(object sender, EventArgs e)
        {        
            string jsonfile2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "atsTableInclude.json");
            dataGridView2.DataSource = FillAtsList<atsTableInclude>(jsonfile2);
        }
