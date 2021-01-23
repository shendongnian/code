    public class MainWindow_ViewModel
    {
        public MainWindow_ViewModel() 
        {
            data = new DataHolder();
            foreach (int value in data.Data)
            {
                myData.Add(new Data_DataViewModel() { Value = value });
            }
            this.Pointer = 4;
        }
        private DataHolder data;
        private List<Data_DataViewModel> myData = new List<Data_DataViewModel>();
        public List<Data_DataViewModel> MyDataHolder
        {
            get
            {
                return myData;
            }
        }
        public int Pointer
        {
            get { return this.data.Pointer; }
            set 
            {
                this.data.Pointer = value;
                foreach (Data_DataViewModel dvm in this.myData)
                {
                    dvm.UpdateColor(this.data.Pointer);
                }
            }
        }
    }
