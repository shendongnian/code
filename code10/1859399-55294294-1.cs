    public sealed partial class MainPage : Page
    {
        public ObservableCollection<UpdateData> updateDatas { get; set; }
        public ObservableCollection<UpdateData> selectedData { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            updateDatas = new ObservableCollection<UpdateData>();
            selectedData = new ObservableCollection<UpdateData>();
            for (int i=0;i<10;i++)
            {
                updateDatas.Add(new UpdateData() {ID=i,Judul="Judul "+i });
            }
            this.DataContext = this;
        }
        private void UpdateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                selectedData.Add((UpdateData)item);
            }
            foreach (var item in e.RemovedItems)
            {
                selectedData.Remove((UpdateData)item);
            }
        }
    }
    public class UpdateData
    {
        public int ID { get; set; }
        public string Judul { get; set; }
    }
