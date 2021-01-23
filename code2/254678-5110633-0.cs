                // Copy the file if ANY of the search criteria have been met
                if (found)
                {
                    m_form.Invoke(m_form.m_DelegateAddString, new Object[] {"FOUND: Order_No: " + Order_No +
                                                                            " barcode: " + barcode +
                                                                            " MailerCode: " + MailerCode +
                                                                            " AgentID: " + AgentID +
                                                                            " City: " + City +
                                                                            " State: " + State +
                                                                            " ZIP: " + ZIP});
                    //passes values to TransferFile 
                    TransferFile(directory, barcode, AgentID, ZIP);
                }
            } // end for that finds each matching record 
        }
        // find and copy the file to the target directory string ZIP
        private void TransferFile(string sourceDir, string filename, string AgentID, string ZIP)
        {
            string fullFileName = filename + ".pdf";
            string fullFileNameAndPath = sourceDir + "\\" + fullFileName;
            string targetFileAndPath;
                // adds the given lead's agentid and zip code to the targetpath string 
                string targetzipdir = m_sc.get_TargetPath() + "\\" + AgentID + "\\" + ZIP;
                // If the given lead's zip code subdirectory doesn't exist, create it.
                if (!Directory.Exists(targetzipdir))
                {
                    Directory.CreateDirectory(targetzipdir);
                }
                targetFileAndPath = m_sc.get_TargetPath() + "\\" + AgentID + "\\" + ZIP + "\\" + fullFileName;
            // Copy the file if the source file exists
            if (File.Exists(fullFileNameAndPath))
            {
                m_form.Invoke(m_form.m_DelegateAddString, new Object[] {"COPYING FROM: " + fullFileNameAndPath});
                m_form.Invoke(m_form.m_DelegateAddString, new Object[] {"TO: " + targetFileAndPath});
                
                // Copy the file and over-write the target file if it exists
                File.Copy(fullFileNameAndPath, targetFileAndPath, true);
            }
            else
            {
                m_form.Invoke(m_form.m_DelegateAddString, new Object[] {"Source file does not exist: " + fullFileNameAndPath});
            }
            m_form.Invoke(m_form.m_DelegateAddString, new Object[] {""});
        }
