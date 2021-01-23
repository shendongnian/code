            finally
            {
                // No matter what happens, make sure all the sessions get closed
                foreach (SessionFactoryElement sessionFactorySettings in openSessionInViewSection.SessionFactories)
                {
                    SessionManager.Instance.CloseSessionOn(sessionFactorySettings.FactoryConfigPath);
                }
            }
