    public class BranchLevel_1
    {
        public string Name { get; set; }
        public ObservableCollection<BranchLevel_2> Children { get; set; }
    
        public BranchLevel_1(string name, List<BranchLevel_2> children)
        {
            this.Name = name;
            //this line needs to be added before creating ObservableCollection
            children.OrderBy(item_level2 => item_level2.Contents[1].Content).ToList();
            this.Children = new ObservableCollection<BranchLevel_2>(children);
        }
    }
