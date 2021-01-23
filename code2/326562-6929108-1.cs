     public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var myAdornerLayer = AdornerLayer.GetAdornerLayer(MyDoc);
            myAdornerLayer.Add(new SimpleCircleAdorner(MyDoc));
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LocalPrintServer ps = new LocalPrintServer();
            PrintQueue pq = ps.DefaultPrintQueue;
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
            PrintTicket pt = pq.UserPrintTicket;
            if (xpsdw != null)
            {
                pt.PageOrientation = PageOrientation.Portrait;
                PageMediaSize pageMediaSize = new PageMediaSize(this.ActualWidth, this.ActualHeight);
                pt.PageMediaSize = pageMediaSize;
                xpsdw.Write(MyContent);
            }
        }
    }
