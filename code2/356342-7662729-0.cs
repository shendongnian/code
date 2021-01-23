    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var persons = CreatePersons();
                GridView1.DataSource = persons;
                GridView1.DataBind();
            }
        }
        private List<PersonRecord> CreatePersons()
        {
            var person = new PersonRecord
                             {
                                 PersonId = 1,
                                 Name = "greg",
                                 Title = "Supreme Coder",
                                 Description = "Nada",
                                 Notes = "foo bar"
                             };
            var person2 = new PersonRecord
            {
                PersonId = 2,
                Name = "Sam",
                Title = "Junior Coder",
                Description = "Nada",
                Notes = "foo bar"
            };
            var list = new List<PersonRecord> {person, person2};
            return list;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var row = GridView1.Rows[0];
            var cell = row.Cells[1];
            var value = cell.Text;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            var row = GridView1.Rows[index];
            var nameCell = row.Cells[2];
            var name = nameCell.Text;
            Label1.Text = name;
        }
    }
