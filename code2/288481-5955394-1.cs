    public partial class Form1 : Form
    {
        List<Cat> cats = new List<Cat>();
        public Form1()
        {
            InitializeComponent();
            cats.Add(new Cat() { Name = "Felix", Description = "Classic Cat" });
            cats.Add(new Cat() { Name = "Garfield", Description = "Fat,Lazy" });
            cats.Add(new Cat() { Name = "Tom", Description = "Wanna-Be-Mouser" });
            cats[0].AddCheezburger(new Cheezburger() { CanHaz = true, PattyCount = 1 });
            cats[0].AddCheezburger(new Cheezburger() { CanHaz = false, PattyCount = 3 });
            cats[1].AddCheezburger(new Cheezburger() { CanHaz = false, PattyCount = 2 });
            cats[1].AddCheezburger(new Cheezburger() { CanHaz = true, PattyCount = 7 });
            cats[1].AddCheezburger(new Cheezburger() { CanHaz = true, PattyCount = 99 });
            cats[2].AddCheezburger(new Cheezburger() { CanHaz = true, PattyCount = 5 });
            cats[2].AddCheezburger(new Cheezburger() { CanHaz = false, PattyCount = 14 });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cats;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = serializeCats(cats);
        }
        private DataTable serializeCats(List<Cat> cats)
        {
            DataTable returnTable = new DataTable("Cats");
            returnTable.Columns.Add(new DataColumn("Name"));
            returnTable.Columns.Add(new DataColumn("Description"));
            int setID = 1;
            foreach (Cat cat in cats)
            {
                //If the row requires more columns than are present then add additional columns
                int totalColumnsRequired = (cat.Cheezbugers.Count * 2) + 2;
                while (returnTable.Columns.Count < totalColumnsRequired)
                {
                    returnTable.Columns.Add(new DataColumn("Can Haz " + setID.ToString()));
                    returnTable.Columns.Add(new DataColumn("Patty Count " + setID.ToString()));
                    setID++;
                }
                returnTable.AcceptChanges();
                DataRow row = returnTable.NewRow();
                row[0] = cat.Name;
                row[1] = cat.Description;
                int cbi = 2; //cheezburger index
                foreach (Cheezburger cheezburger in cat.Cheezbugers)
                {
                    row[cbi] = cheezburger.CanHaz;
                    cbi++;
                    row[cbi] = cheezburger.PattyCount;
                    cbi++;
                }
                returnTable.Rows.Add(row);
            }
            return returnTable;
        }
    }
