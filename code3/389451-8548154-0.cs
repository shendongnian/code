        private void EncryptOrDecryptFile(string strInputFile, string strOutputFile, byte[] bytKey, byte[] bytIV, CryptoAction Direction)
        {
            //In case of errors.
            try
            {
                if (string.IsNullOrEmpty(strInputFile))
                {
                    MessageBox.Show("Please select an input file name", "Missing file name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!File.Exists(strInputFile))
                {
                    MessageBox.Show(string.Format("The selected input file {0} does not exist.", strInputFile), "Invalid Path or Filename", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(strOutputFile))
                {
                    MessageBox.Show("Please select an output file name", "Missing file name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //holds a block of bytes for processing
                long lngBytesProcessed = 0;
                // Setup file streams to handle input and output.
                using (var fsInput = new System.IO.FileStream(strInputFile, FileMode.Open, FileAccess.Read))
                {
                    using (var fsOutput = new System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        //Declare your CryptoServiceProvider.
                        using (var cspRijndael = new System.Security.Cryptography.RijndaelManaged())
                        {
                            try
                            {
                                //Setup Progress Bar
                                pbStatus.Value = 0;
                                pbStatus.Maximum = 100;
                                cspRijndael.Key = bytKey;
                                cspRijndael.IV = bytIV;
                                ICryptoTransform oTransform = null;
                                // Determine if ecryption or decryption and setup transform.
                                switch (Direction)
                                {
                                    case CryptoAction.ActionEncrypt:
                                        oTransform = cspRijndael.CreateEncryptor();
                                        break;
                                    case CryptoAction.ActionDecrypt:
                                        oTransform = cspRijndael.CreateDecryptor();
                                        break;
                                    default:
                                        throw new Exception("Unknown Direction");
                                }
                                using (var csCryptoStream = new CryptoStream(fsOutput, oTransform, CryptoStreamMode.Write))
                                {
                                    //Declare variables for encrypt/decrypt process.
                                    byte[] bytBuffer = new byte[4097];
                                    //running count of bytes processed
                                    long lngFileLength = fsInput.Length;
                                    //the input file's length
                                    int intBytesInCurrentBlock = 0;
                                    //Use While to loop until all of the file is processed.
                                    while (lngBytesProcessed < lngFileLength)
                                    {
                                        //Read file with the input filestream.
                                        intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096);
                                        //Write output file with the cryptostream.
                                        csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock);
                                        //Update lngBytesProcessed
                                        lngBytesProcessed = lngBytesProcessed + Convert.ToInt64(intBytesInCurrentBlock);
                                        //Update Progress Bar
                                        pbStatus.Value = Convert.ToInt32((lngBytesProcessed / lngFileLength) * 100);
                                    }
                                }
                            }
                            finally
                            {
                                if (cspRijndael != null)
                                {
                                    // Clear the managed object
                                    cspRijndael.Clear();
                                }
                            }
                        }
                    }
                }
                // If encrypting then delete the original unencrypted file.
                if (Direction == CryptoAction.ActionEncrypt)
                {
                    File.Delete(strFileToEncrypt);
                }
                // If decrypting then delete the encrypted file.
                if (Direction == CryptoAction.ActionDecrypt)
                {
                    File.Delete(strFileToDecrypt);
                }
                // Update the user when the file is done.
                string Wrap = "\r\n";
                if (Direction == CryptoAction.ActionEncrypt)
                {
                    MessageBox.Show("Encryption Complete" + Wrap + Wrap + "Total bytes processed = " + lngBytesProcessed.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Update the progress bar and textboxes.
                    pbStatus.Value = 0;
                    txtFileToEncrypt.Text = "Click Browse to load file.";
                    txtPassEncrypt.Text = "";
                    txtConPassEncrypt.Text = "";
                    txtDestinationEncrypt.Text = "";
                    btnChangeEncrypt.Enabled = false;
                    btnEncrypt.Enabled = false;
                }
                else
                {
                    //Update the user when the file is done.
                    MessageBox.Show("Decryption Complete" + Wrap + Wrap + "Total bytes processed = " + lngBytesProcessed.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Update the progress bar and textboxes.
                    pbStatus.Value = 0;
                    txtFileToDecrypt.Text = "Click Browse to load file.";
                    txtPassDecrypt.Text = "";
                    txtConPassDecrypt.Text = "";
                    txtDestinationDecrypt.Text = "";
                    btnChangeDecrypt.Enabled = false;
                    btnDecrypt.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown exception occurred: " + ex.Message, "Unknown Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // Catch all other errors. And delete partial files.
                if (Direction == CryptoAction.ActionDecrypt)
                {
                    if (!string.IsNullOrEmpty(txtDestinationDecrypt.Text) && (File.Exists(txtDestinationDecrypt.Text)))
                    {
                        File.Delete(txtDestinationDecrypt.Text);
                    }
                    pbStatus.Value = 0;
                    txtPassDecrypt.Text = "";
                    txtConPassDecrypt.Text = "";
                    MessageBox.Show("Please check to make sure that you entered the correct password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDestinationEncrypt.Text) && (File.Exists(txtDestinationEncrypt.Text)))
                    {
                        File.Delete(txtDestinationEncrypt.Text);
                    }
                    pbStatus.Value = 0;
                    txtPassEncrypt.Text = "";
                    txtConPassEncrypt.Text = "";
                    MessageBox.Show("This file cannot be encrypted.", "File Cannot Be Encrypted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
