    public partial class UserControl1 : UserControl
    {
      internal Int32 _caseID;
      internal object _objectID;
      public int CaseID { get => _caseID; set => _caseID = value; }
      public object ObjectID { get => _objectID; set => _objectID = value; }
      internal virtual void MakeScreenReadOnly()
      {
      }
      public UserControl1()
      {
        InitializeComponent();
        Type systemType = this.GetType();
        PropertyInfo propertyInfo = systemType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        this.AutoScroll = true;
      }
    }
