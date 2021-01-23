     public static class Account
        {
            public static int UserID
            {
                get { return Session[SessionVariables.UserID]; }
                set { Session[SessionVariables.UserID] = value; }
            }
        
            // .... and so on
        }
