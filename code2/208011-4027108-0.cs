    public class MainForm : Form
    {
        public void AddView(UserControl view)
        {
            SuspendLayout();
            Controls.Add(view);
            ResumeLayout(true);
        }
    }
