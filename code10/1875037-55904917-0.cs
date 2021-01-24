    public class BranchLevel_2
    {
        public ObservableCollection<BranchLevel_3> Contents { get; set; }
    
        public BranchLevel_2(List<string> contents)
        {
            this.Contents = new ObservableCollection<BranchLevel_3>();
            foreach (var content in contents.OrderBy(c => c))
            {
                this.Contents.Add(new BranchLevel_3(content));
            }
        }
    }
