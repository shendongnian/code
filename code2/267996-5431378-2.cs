    public partial class AdminController : UserControl
    {
        public delegate void AdminControllerEvent(object sender, AdminControllerEventArgs e);
    
        public event AdminControllerEvent AddUpdateClick;
        public event AdminControllerEvent DeleteClick;
