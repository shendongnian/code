        [WebMethod(EnableSession = true)] 
        public void Open(string login, string password) { 
            MNConnection _conn = new MNConnection();
            _conn.Open(login, password); 
            HttpContext.Current.Session["MyConn"] = _conn;
            HttpContext.Current.Session["LPU"] = _conn.CreateLPU();
        } 
 
        [WebMethod(EnableSession = true)] 
        public decimal Get() {
            MNLPU _lpu = HttpContext.Current.Session["LPU"] as MNLPU; 
            return _lpu.Count; 
        } 
