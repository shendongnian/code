        public CompositeControl() {
            InitializeComponent();
            PreviewDragEnter += new DragEventHandler(CompositeControl_DragEnter);
            PreviewDragOver += new DragEventHandler(CompositeControl_DragEnter);
            textBox1.PreviewDragEnter += new DragEventHandler(textBox_PreviewDragEnter);
            textBox1.PreviewDragOver += new DragEventHandler(textBox_PreviewDragEnter);
            textBox1.PreviewDrop += new DragEventHandler(CompositeControl_Drop);
            textBox2.PreviewDragEnter += new DragEventHandler(textBox_PreviewDragEnter);
            textBox2.PreviewDragOver += new DragEventHandler(textBox_PreviewDragEnter);
            textBox2.PreviewDrop += new DragEventHandler(CompositeControl_Drop);
            Drop += new DragEventHandler(CompositeControl_Drop);
        }
        void textBox_PreviewDragEnter(object sender, DragEventArgs e) {
            e.Handled = true;
        }
    
