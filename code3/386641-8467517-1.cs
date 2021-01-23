    public static class Config {
        public static bool LoggedIn { get; private set; }
    
        public static Login ()
        {
            var frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK) {
                LoggedIn = frm.LoggedIn;
            }
        }
    }
