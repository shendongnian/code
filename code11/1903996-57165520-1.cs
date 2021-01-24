    public class MainWindowCtrl
    {
        public MainWindowCtrl()
        {
            this.view = new MainWindowView();
            this.view.Editor.KeyDown += (sender, e) => this.OnEditorKeyDown( e );
            this.view.FormClosed += (sender, e) => Application.Exit();
            this.view.Show();
        }
        void OnEditorKeyDown(KeyEventArgs e)
        {
            this.view.StatusBar.Text = "Ready";
            if (e.KeyData == Keys.Enter)
            {
                this.view.StatusBar.Text = "Press Shift + Return!!";
                //MessageBox.Show( "Press Shift + Return!!" );
                e.SuppressKeyPress = true;
                return;
            }
            if (e.KeyData == (Keys.Shift | Keys.Enter))
            {
                int pos = this.view.Editor.SelectionStart;
                this.view.Editor.SelectedText = System.Environment.NewLine;
                this.view.Editor.SelectionStart = pos + 2;
                e.Handled = e.SuppressKeyPress = true;
                return;
            }
        }
        MainWindowView view;
    }
