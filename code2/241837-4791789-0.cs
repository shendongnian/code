    public partial class Window1 : Window
        {
            public delegate void CreateCanvasHandler(Grid parent, int index);
    
            public Window1()
            {
                InitializeComponent();
    
                int count = 10000;
    
                this.TestCreateAsync(count);
            }
    
            private void TestCreateAsync(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    //check the DispatecherOperation status
                    this.LayoutRoot.Dispatcher.BeginInvoke(new CreateCanvasHandler(this.CreateCanvas),
                        DispatcherPriority.Background,
                        new object[2] 
                        { 
                            this.LayoutRoot,
                            i
                        });   
                }
            }
    
            private void CreateCanvas(Grid parent,
                int index)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 200,
                    Height = 100
                };
    
                canvas.Children.Add(new TextBlock()
                {
                    Text = index.ToString(),
                    FontSize = 14,
                    Foreground = Brushes.Black
                });
    
                Thread.Sleep(100);
    
                parent.Children.Add(canvas);
            }
        }
