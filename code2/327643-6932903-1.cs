    /// <summary>
    /// The form internally used by <see cref="CustomMessageBox"/> class.
    /// </summary>
    internal partial class CustomMessageForm : Form
    {
        /// <summary>
        /// This constructor is required for designer support.
        /// </summary>
        public CustomMessageForm ()
        {
            InitializeComponent(); 
        } 
        public CustomMessageForm (string title, string description)
        {
            InitializeComponent(); 
             
            this.titleLabel.Text = title;
            this.descriptionLabel.Text = description;
        } 
    }
    /// <summary>
    /// Your custom message box helper.
    /// </summary>
    public static class CustomMessageBox
    {
        public static void Show (string title, string description)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new CustomMessageForm (title, description)) {
                form.ShowDialog ();
            }
        }
    }
