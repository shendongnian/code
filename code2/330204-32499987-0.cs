    public class MyForm : Form
    {
        private Size defaultSize;
        public MyForm()
        {
            InitializeComponent();
            this.defaultSize = this.Size;
            this.fireOnBeforeLoad = true;
        }
        public new void ResumeLayout(bool performLayout)
        {
            base.ResumeLayout(performLayout);
            if (fireOnBeforeLoad)
            {
                fireOnBeforeLoad = false;
                OnBeforeLoad();
            }
        }
        protected virtual void OnBeforeLoad()
        {
            form.WindowState = FormWindowState.Normal;
            form.Size = defaultSize;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            var area = Screen.FromControl(form).WorkingArea;
            form.Size = defaultSize;
            form.Location = new System.Drawing.Point(
                (int)(area.Width - form.Width) / 2, 
                (int)(area.Height - form.Height) / 2);
        }
    }
