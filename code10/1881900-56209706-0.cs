    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum BookCategory
        {
            Comics = 1,
            Crafts = 2,
            Education = 3,
            History = 4,
            Entertainment = 5,
            Thriller = 6,
            Religion = 7,
            Romance = 8,
            Fantasy = 9,
            Sports = 10
        }              
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var values = Enum.GetValues(typeof(BookCategory));
            var dataSource = new List<BookCategoryData>();
            foreach (var bookCatergory in values)
            {
                dataSource.Add(new BookCategoryData() { Id = (int)bookCatergory, Name = bookCatergory.ToString() });
            }
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = dataSource;
            
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
    public class BookCategoryData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
