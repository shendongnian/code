    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //do your time consuming stuff
            while (m_Active)
            {
                Thread.Sleep(100);
                int lData = m_Stream.Read(m_Buffer, 0,
                      m_Client.ReceiveBufferSize);
                String myString = Encoding.UTF7.GetString(m_Buffer);
                e.result = myString.Substring(0, lData);
                
                ParseString(e.Result.ToString());
            }
        }
     private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update your UI if needed
        }
