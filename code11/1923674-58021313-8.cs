    public class ParentViewModel
    {
        public RelayCommand<object> ParentSaveCommand { get; set; }
        public ParentViewModel()
        {
            this.ParentSaveCommand = new RelayCommand<object>(obj => this.ParentSaveExecute(obj));
        }
        private void ParentSaveExecute(object items)
        {
            foreach (var item in (ChildViewModel[])items)
            {
                item.SaveCommand.Execute();
            }
        }
    }
