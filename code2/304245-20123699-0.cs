                m_SqlConnection = new SqlConnection(ConnectionStringBuilder.ConnectionString);
                m_SqlConnection.StateChange += new System.Data.StateChangeEventHandler(m_SqlConnection_StateChange);
                m_SqlConnection.Open();
        void m_SqlConnection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            try
            {
                if (m_SqlConnection.State == ConnectionState.Open)
                {
                    //do stuff
                }
                if (m_SqlConnection.State == ConnectionState.Broken)
                {
                    Close();
                }
                if (m_SqlConnection.State == ConnectionState.Closed)
                {
                    Open();
                }
            }
            catch
            {
            }
        }
