    using System;
    System.Web.SessionState;
    
    public class TimeoutControlPage: System.Web.UI.Page {
        public int Timeout {
            get { return Session.Timeout; }    
            set { Session.Timeout = value; }
       }
