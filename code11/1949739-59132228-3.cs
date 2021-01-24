    public DemoTreeViewModel()
        {
            MyTree = new DemoTreeNode { Title = "Root", Score = 0.5, IsExpanded = true };
            var a = MyTree.Children.Add(new DemoTreeNode { Title = "Branch A", Imagepath = "plu3.png", Score = 0.75, IsExpanded = true });
            a.Children.Add(new DemoTreeNode { Title = "Leaf A1",Imagepath="plu3.png", Score = 0.85, IsExpanded = true });
            a.Children.Add(new DemoTreeNode { Title = "Leaf A2", Imagepath = "plu3.png", Score = 0.65, IsExpanded = true });
            var b = MyTree.Children.Add(new DemoTreeNode { Title = "Branch B", Imagepath = "plu3.png", Score = 0.25, IsExpanded = true });
            b.Children.Add(new DemoTreeNode { Title = "Leaf B1", Imagepath = "plu3.png", Score = 0.35, IsExpanded = true });
            b.Children.Add(new DemoTreeNode { Title = "Leaf B2", Imagepath = "plu3.png", Score = 0.15, IsExpanded = true });
            
        }
