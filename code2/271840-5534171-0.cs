    public partial class MainWindow : Window
    {        
           
        public MainWindow()
        {
            InitializeComponent();
            AddCanvasToWrapPanel(this.TestWrapPanel);
            RemoveLastCanvasFromWrapPanel(this.TestWrapPanel);
            AddCanvasToWrapPanel(this.TestWrapPanel);
            DestroyCanvasAtWrapPanelIndex(this.TestWrapPanel, 0);
            
        }
        private void AddCanvasToWrapPanel(WrapPanel wp)
        {
            TextBox t = new TextBox();
            Canvas c = new Canvas();
            c.Children.Add(t);
            wp.Children.Add(c);
        }
        private void RemoveLastCanvasFromWrapPanel(WrapPanel wp)
        {
            wp.Children.RemoveAt(wp.Children.Count - 1);
        }
        private void DestroyCanvasAtWrapPanelIndex(WrapPanel wp, int index)
        {
            wp.Children.RemoveAt(index);
        }
        
    }
    }
