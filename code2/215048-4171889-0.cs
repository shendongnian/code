     public static SessionConfig Current
            {
                get
                {
                    SessionConfig session =
                      (SessionConfig)HttpContext.Current.Session["__SessionConfig__"];
                    if (session == null)
                    {
                        session = new SessionConfig();
                        HttpContext.Current.Session["__SessionConfig__"] = session;
                    }
                    return session;
                }
            }
