    public partial class Window1 : UserControl
        {
            List<Person> CanvasDatasource { get; set; }
            List<Category> TreeViewDatasource { get; set; }
    
            public Window1()
            {
                InitializeComponent();
                TreeViewDatasource = new List<Category>();
    
                for (int i = 0; i < 5; i++)
                {
                    Category c = new Category();
                    c.Name = "category" + i;
                    for (int j = 0; j < 5; j++)
                    {
                        c.persons.Add(new Person { Name = "Person " + j });
                    }
    
                    TreeViewDatasource.Add(c);
                }
    
                CanvasDatasource = TreeViewDatasource.SelectMany(i => i.persons.Select(j => j)).ToList();
    
            }
    
    
        }
    
        class Category
        {
            public Category()
            {
                persons = new List<Person>();
            }
            public string Name { get; set; }
            public List<Person> persons { get; set; }
        }
    
        class Person
        {
            public string Name { get; set; }
        }
