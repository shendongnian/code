    public class ReportServerCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        #region private members
    
        private string _username;
        private string _password;
        private string _domain;
    
        #endregion
    
        #region Constructor
    
    
        /// <summary>
        /// Initializes itself with ReportServerUsername, ReportServerPassword and ReportServerDomain settings from web.config 
        /// </summary>
        public ReportServerCredentials()
        {
            this._username = "USERNAME";
            this._password = "PASSWORD";
            this._domain = ""; // set if its domain server
        }
    
        public ReportServerCredentials(string username, string password, string domain)
        {
            this._username = username;
            this._password = password;
            this._domain = domain;
        }
    
        #endregion
    
        #region IReportServerCredentials Members
    
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = password = authority = null;
            return false;
        }
    
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }
    
        /// <summary>
        /// Creates a System.Net.NetworkCredential object with the specified username, password and domain.
        /// </summary>
        public System.Net.ICredentials NetworkCredentials
        {
            get { return new System.Net.NetworkCredential(_username, _password, _domain); }
        }
    
        #endregion
    }
