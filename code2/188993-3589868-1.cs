    public partial class CollectionBaseForm : BaseForm
        {
            protected internal ToolStripMenuItem ReportMenu { get { return this.reportsToolStripMenuItem; } set { this.reportsToolStripMenuItem = value; } }
            protected internal DataGridView DataGridView { get {return this.dataGridView1 ;} set {dataGridView1 = value ;} }
            protected internal Button SearchButton { get { return btnSearch; } set { btnSearch = value; } }
            protected internal Button AddNewButton { get { return btnAddNew; } set { btnAddNew = value; } }
            protected internal Button EditButton { get { return btnEdit; } set { btnEdit = value; } }
            protected internal Button DeleteButton { get { return btnDelete; } set { btnDelete = value; } }
            protected internal Button PickButton { get { return btnPick; } set { btnPick = value; } }
    
            private FormViewMode _formViewMode;
            public FormViewMode FormViewMode 
            {
                get 
                {
                    return _formViewMode;
                }
                set
                {
                    _formViewMode = value;
    
                    EnableDisableAppropriateButtons(_formViewMode);
                }
            }
    
            private void EnableDisableAppropriateButtons(FormViewMode FormViewMode)
            {
                if (FormViewMode == FormViewMode.Collection)
                {
                    AddNewButton.Enabled = true;
                    EditButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    PickButton.Enabled = false;
                }
                else if (FormViewMode == FormViewMode.Picker)
                {
                    AddNewButton.Enabled = false;
                    EditButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    PickButton.Enabled = true;
                }
            }
    
            public CollectionBaseForm()
            {
                InitializeComponent();
    
                this.MaximumSize = this.MinimumSize = this.Size;
    
                this.FormViewMode = FormViewMode.Collection;
            }
    
            private void closeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
            }            
        }
