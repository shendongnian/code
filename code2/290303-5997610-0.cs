     public void ConnectButtonPressed()
                {
                    var threadedTask = () => m_Model.Connect(m_View.Hostname, m_View.Port);
                    threadedTask.BeginInvoke(null,null);
                }
