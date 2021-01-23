    public partial class MyForm : Form
    {
        private readonly SynchronizationContext _context;
        public MyForm()
        {
            _context = SynchronizationContext.Current
            //...
        }
    
        private MethodOnOtherThread()
        {
             //...
             _context.Post(status => 
              {
                 // I think it's enough to check the form's IsDisposed
                 // But if you want to be extra paranoid you can test someLabel.IsDisposed
                 if (!IsDisposed) {someLabel.Text = newText;}
              },null);
        }
    }
