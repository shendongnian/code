        public MainWindow()
        {
            // Initialize UI
            InitializeComponent();
            // Loaded event
            this.Loaded += delegate
                {
                    TextBox1.AllowDrop = true;
                    TextBox1.PreviewDragEnter += TextBox1PreviewDragEnter;
                    TextBox1.PreviewDragOver += TextBox1PreviewDragOver;
                    TextBox1.PreviewDrop += TextBox1DragDrop;
                };
        }
        /// <summary>
        /// We have to override this to allow drop functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TextBox1PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
        
        /// <summary>
        /// Evaluates the Data and performs the DragDropEffect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1PreviewDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
        /// <summary>
        /// The drop activity on the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1DragDrop(object sender, DragEventArgs e)
        {
            // Get data object
            var dataObject = e.Data as DataObject;
            // Check for file list
            if (dataObject.ContainsFileDropList())
            {
                // Clear values
                TextBox1.Text = string.Empty;
                // Process file names
                StringCollection fileNames = dataObject.GetFileDropList();
                StringBuilder bd = new StringBuilder();
                foreach (var fileName in fileNames)
                {
                    bd.Append(fileName + "\n");
                }
                // Set text
                TextBox1.Text = bd.ToString();
            }
        }
