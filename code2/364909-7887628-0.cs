    public Form1()
    {
        InitializeComponent();
    
        MyBindingList<BackingObject> backing_objects = new MyBindingList<BackingObject>();
        backing_objects.Add(new BackingObject{ PrimaryKey = 1, Name  = "Fred", Hidden = "Fred 1"});          
    
        dataGridView1.DataSource = backing_objects;
    
        this.Load += new EventHandler(Form1_Load);
        dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
    }
    
    void Form1_Load(object sender, EventArgs e)
    {
        Console.WriteLine("Load");
    }
    
    void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        Console.WriteLine("Selection Changed");            
    }
