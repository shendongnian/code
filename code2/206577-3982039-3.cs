    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the datacontext
            this.DataContext = this;
            // Sample array generation
            byte[] array = new byte[138];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (byte)i;
            }
            int length = (int)Math.Ceiling(array.Length / 10m);
            Bytes = (from i in Enumerable.Range(0, length)
                    let offset = i * 10
                    let count = offset + 10 > array.Length ? array.Length - offset : 10
                    select new ArrayPiece<byte>(array, offset, count)).ToArray();
        }
        ArrayPiece<byte>[] _bytes;
        public ArrayPiece<byte>[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; OnPropertyChanged("Bytes"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public struct ArrayPiece<T>
    {
        public T[] Piece { get; set; }
        
        public ArrayPiece(T[] array, int offset, int length) : this()
        {
            Piece = new T[length];
            Buffer.BlockCopy(array, offset, Piece, 0, length);
        }
    }
