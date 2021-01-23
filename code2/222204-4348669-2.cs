    using System.Windows.Forms.Integration; 
    public MyForm() {
        InitializeComponent();
        elementHost.ChildChanged += ElementHost_ChildChanged;
    }
    void ElementHost_ChildChanged(object sender, ChildChangedEventArgs e) {
        var ctr = (elementHost.Child as UserControl1);
        if (ctr != null)
            ctr.FormsWindow = this;
    }
