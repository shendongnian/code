    public MainWindow()
    {
      InitializeComponent();
    
      List<BinaryTreeData> myBinaryData = new List<BinaryTreeData>();
      
      BinaryTreeData parent1 = new BinaryTreeData() { ownID = 1 };
      parent1.Subitems.Add(new BinaryTreeData { ownID = 2 });
      parent1.Subitems.Add(new BinaryTreeData { ownID = 3 });
      
      BinaryTreeData parent2 = new BinaryTreeData() { ownID = 4 };
      parent2.Subitems.Add(new BinaryTreeData { ownID = 5 });
      parent2.Subitems.Add(new BinaryTreeData { ownID = 6 });
    
      myBinaryData.Add(parent1);
      myBinaryData.Add(parent2);
    
      myTreeView.ItemsSource = myBinaryData;
    }
