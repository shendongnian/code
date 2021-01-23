    public class CompositeScroll
    {
        private List<Scrollbar> scrollbars = new List<Scrollbars>();
        public void AddScrollbar(Scrollbar scrollbar)
        {
            scrollbars.Add(scrollbar);
            scrollbar.OnScroll += OnScroll;
        }
         
        private void OnScroll(object sender, EventArgs e)
        {
            var current = (Scrollbar)sender;
            var scrollbarsToMove = scrollbars.Where(x => x != current);
   
            foreach(var scrollbar in scrollbarsToMove)
                scrollbar.Position = current.Position;
        }
    }
    public class MyForm : Form
    {
        private CompositeScroll compositeScroll = new CompositeScroll();        
        public MyForm()
        {
            InitializeComponents();
            compositeScroll.AddScrollbar(scrollbar1);
            compositeScroll.AddScrollbar(scrollbar2);
            compositeScroll.AddScrollbar(scrollbar3);
            compositeScroll.AddScrollbar(scrollbar4);
        }
    }
