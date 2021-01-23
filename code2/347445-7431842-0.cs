    namespace WinFormsApp
    {
        public partial class Form1 : Form
        {
            private List<Category> categories;
    
            public Form1()
            {
                InitializeComponent();
    
                categories = new List<Category>();
    
                var categoryOne = new Category { Name = "Category 1"} ;
                categoryOne.Items.Add( new CategoryItem { Name = "Item 1"} );
    
                var categoryTwo = new Category { Name = "Category 2" };
                categoryTwo.Items.Add( new CategoryItem { Name = "Item 2" } );
    
                categories.Add( categoryOne );
                categories.Add( categoryTwo );
            }
    
            private void Form1_Load(object sender, System.EventArgs e)
            {
                categoryBindingSource.DataSource = categories;
            }
        }
    
        public class Category
        {
            public string Name { get; set; }
    
            public List<CategoryItem> Items { get; private set; }
    
            public Category()
            {
                Items = new List<CategoryItem>();
            }
        }
    
        public class CategoryItem
        {
            public string Name { get; set; }
        }
    }
