    class MainClass
    {
       public string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
       public void showWindow(Form openWin, Form closeWin, Form MDI)
        {
            closeWin.Close();
            openWin.WindowState = FormWindowState.Minimized;
            openWin.MdiParent = MDI;
            openWin.Show();
        }
    }
