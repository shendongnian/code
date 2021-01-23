    public partial class BaseForm : Form
        {
            ///////////Event Mechanism///////////
            protected internal event ItemStateChanged ItemStateChangeEvent;
            protected internal void OnItemStateChanged()
            {
                if (ItemStateChangeEvent != null)
                {
                    ItemStateChangeEvent();
                }
            }
            ///////////Event Mechanism///////////
    
            protected internal Label ErrorMessageTextBox 
            {
                get { return this.errorMessageTextBox; }
                set { this.errorMessageTextBox = value; }
            }
    
            protected internal ToolStripStatusLabel TotalToolStripStatusLabel
            {
                get { return this.totalToolStripStatusLabel; }
                set { this.totalToolStripStatusLabel = value; }
            }
    
            protected internal FormViewMode FormViewMode { get; set; }
    
            public BaseForm()
            {
                InitializeComponent();
            }
        }
