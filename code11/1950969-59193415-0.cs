        public void SaveCsvToDatabase(string strDirectory)
        {
            if (ConnectToDatabase())
            {
                //We need to specify file we are looking to process exists.
                int fileCount = Directory.GetFiles(@"\\company\Archive\IN\InvoiceTest\Inbox\").Length;
                //And specify the name of the file in the path we want. 
                DirectoryInfo diFileCheck = new DirectoryInfo(@"\\company\EDIArchive\IN\InvoiceTest\Inbox\");
                foreach (var file in diFileCheck.GetFiles())
                {
                    string strSourceFile = file.FullName;
                    if (File.Exists(strSourceFile))
                    {
                        //save our file to the database
                        string strFileInsert = "INSERT INTO InvoiceHdr" +
                                               " (fileName) VALUES ('" + MySqlHelper.EscapeString(strSourceFile) + "')";
                        MySqlCommand command = new MySqlCommand(strFileInsert, con);
                        if (command.ExecuteNonQuery() == 1)
                        {
                            //we've inserted our row, now get the new id
                            m_iFileId = command.LastInsertedId;
                            if (m_iFileId != 0)
                            {
                                SaveCsvLines(strSourceFile);
                            }
                        ArchiveFile();
                        }
                    }
                }
                if (fileCount == 0)
                {
                    //If we cant count any files in the specified path, we can display a message box warning us. 
                    string strMessage = "No file found in directory: \n\n" + strDirectory;
                    MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
