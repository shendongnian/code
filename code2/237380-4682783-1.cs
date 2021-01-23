    public class SimpleReportViewer : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleReportViewer"/> class.
        /// </summary>
        //You can remove this constructor if you don't want to use the IDE forms designer to tweak its layout.
        public SimpleReportViewer()
        {
            InitializeComponent();
            if(!DesignMode) throw new InvalidOperationException("Default constructor is for designer use only. Use static methods instead.");
        }
        private SimpleReportViewer(string reportText)
        {
            InitializeComponent();
            txtReportContents.Text = reportText;
        }
        private SimpleReportViewer(string reportText, string reportTitle)
        {
            InitializeComponent();
            txtReportContents.Text = reportText;
            Text = "Report Viewer: {0}".FormatWith(reportTitle);
        }
        /// <summary>
        /// Shows a SimpleReportViewer with the specified text and title.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="reportTitle">The report title.</param>
        public static void Show(string reportText, string reportTitle)
        {
            new SimpleReportViewer(reportText, reportTitle).Show();
        }
        /// <summary>
        /// Shows a SimpleReportViewer with the specified text, title, and parent form.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="reportTitle">The report title.</param>
        /// <param name="owner">The owner.</param>
        public static void Show(string reportText, string reportTitle, Form owner)
        {
            new SimpleReportViewer(reportText, reportTitle).Show(owner);
        }
        /// <summary>
        /// Shows a SimpleReportViewer with the specified text, title, and parent form as a modal dialog that prevents focus transfer.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="reportTitle">The report title.</param>
        /// <param name="owner">The owner.</param>
        public static void ShowDialog(string reportText, string reportTitle, Form owner)
        {
            new SimpleReportViewer(reportText, reportTitle).ShowDialog(owner);
        }
        /// <summary>
        /// Shows a SimpleReportViewer with the specified text and the default window title.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        public static void Show(string reportText)
        {
            new SimpleReportViewer(reportText).Show();
        }
        /// <summary>
        /// Shows a SimpleReportViewer with the specified text, the default window title, and the specified parent form.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="owner">The owner.</param>
        public static void Show(string reportText, Form owner)
        {
            new SimpleReportViewer(reportText).Show(owner);
        }
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleReportViewer));
            this.txtReportContents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtReportContents
            // 
            this.txtReportContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                   | System.Windows.Forms.AnchorStyles.Left)
                                                                                  | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportContents.Location = new System.Drawing.Point(13, 13);
            this.txtReportContents.Multiline = true;
            this.txtReportContents.Name = "txtReportContents";
            this.txtReportContents.ReadOnly = true;
            this.txtReportContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReportContents.Size = new System.Drawing.Size(383, 227);
            this.txtReportContents.TabIndex = 0;
            // 
            // SimpleReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 252);
            this.Controls.Add(this.txtReportContents);
            this.Icon = Properties.Resources.some_icon;
            this.Name = "SimpleReportViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Report Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private TextBox txtReportContents;
    }
