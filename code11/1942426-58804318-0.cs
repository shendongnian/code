    string m_documentFile = "e:\\test2\\EncryptedBook1j.xls";
                //Get the password list to store into arrays.
                string[] m_passwordList = { "001", "002", "003", "004", "005", "006", "007", "008" };
                Workbook _workBook;
                int i = 0;
                int ncnt = 0;
    
                //Check if the file is password protected.
                FileFormatInfo fft = FileFormatUtil.DetectFileFormat(m_documentFile);
                bool check = fft.IsEncrypted;
            RetryLabel:
                try
                {
                    if (check)
                    {
    
                        LoadOptions loadOps = new LoadOptions();
    
                        for (i = ncnt; i < m_passwordList.Length; i++)
                        {
    
                            loadOps.Password = m_passwordList[i];
                            _workBook = new Workbook(m_documentFile, loadOps);
                            MessageBox.Show("Opened Successfully with the Password:" + m_passwordList[i]);
                            break;
    
    
                        }
    
                    }
                }
                catch (Exception ex)
                {
    
                    if (ex.Message.CompareTo("Invalid password.") == 0)
                    {
    
                        MessageBox.Show("Invalid Password: " + m_passwordList[i] + " ,trying another in the list");
                        ncnt = i + 1;
                        goto RetryLabel;
    
                    }
    
    
                }
