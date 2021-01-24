    public class SampleContainerVM
    {
        public ObservableCollection<SampleVM> SampleList { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public SampleContainerVM()
        {
            SampleList = new ObservableCollection<SampleVM>();
            AddCommand = new DelegateCommand(
                AddSample,
                () => { return true; });
        }
        private void AddSample()
        {
            SampleList.Add(new SampleVM());
        }
    }
