    public partial class MainWindow : Window
    {
        public Branch Branch { get; set; }
        public MainWindow()
        {
            Branch = new Branch()
            {
                Id = "1",
                Name = "A",
                Branches = new ObservableCollection<Branch>()
                {
                    new Branch()
                    {
                        Id = "2",
                        Name = "B",
                        Branches = new ObservableCollection<Branch>()
                        {
                            new Branch()
                            {
                                Id = "3",
                                Name = "C",
                            },
                            new Branch()
                            {
                                Id = "3",
                                Name = "C",
                                Branches = new ObservableCollection<Branch>()
                                {
                                    new Branch()
                                    {
                                        Id = "3",
                                        Name = "C",
                                    },
                                    new Branch()
                                    {
                                        Id = "3",
                                        Name = "C",
                                    }
                                }
                            }
                        }
                    },
                    new Branch()
                    {
                        Id = "2",
                        Name = "B",
                        Branches = new ObservableCollection<Branch>()
                        {
                            new Branch()
                            {
                                Id = "3",
                                Name = "C",
                            }
                        }
                    }
                }
            };
            InitializeComponent();
            this.DataContext = this.Branch;
        }
    }
