    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
    
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask task = new PhotoChooserTask();
            task.Completed += task_Completed;
            task.Show();
        }
    
        private void task_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK)
                return;
    
            const int BLOCK_SIZE = 4096;
    
            Uri uri = new Uri("http://localhost:4223/File/Upload", UriKind.Absolute);
    
            WebClient wc = new WebClient();
            wc.AllowReadStreamBuffering = true;
            wc.AllowWriteStreamBuffering = true;
    
            // what to do when write stream is open
            wc.OpenWriteCompleted += (s, args) =>
            {
                using (BinaryReader br = new BinaryReader(e.ChosenPhoto))
                {
                    using (BinaryWriter bw = new BinaryWriter(args.Result))
                    {
                        long bCount = 0;
                        long fileSize = e.ChosenPhoto.Length;
                        byte[] bytes = new byte[BLOCK_SIZE];
                        do
                        {
                            bytes = br.ReadBytes(BLOCK_SIZE);
                            bCount += bytes.Length;
                            bw.Write(bytes);
                        } while (bCount < fileSize);
                    }
                }
            };
    
            // what to do when writing is complete
            wc.WriteStreamClosed += (s, args) =>
            {
                MessageBox.Show("Send Complete");
            };
    
            // Write to the WebClient
            wc.OpenWriteAsync(uri, "POST");
        }
    }
