    public partial class UserControl1 : UserControl
    {
      private ControlCollection _controls;
      public UserControl1()
      {
         InitializeComponent();
         _controls = new ControlCollection(this);
      }
      new public ControlCollection Controls
      {
         get
         {
            return (_controls != null ? _controls : base.Controls);
         }
      }
    }
