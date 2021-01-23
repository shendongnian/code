// Tell the browser we're sending a ZIP file!
            var downloadFileName = string.Format("Items-{0}.zip", DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "filename=" + downloadFileName);
            // Zip the contents of the selected files
            using (var zip = new ZipFile())
            {
                // Add the password protection, if specified
                /*if (!string.IsNullOrEmpty(txtZIPPassword.Text))
                {
                    zip.Password = txtZIPPassword.Text;
                    // 'This encryption is weak! Please see http://cheeso.members.winisp.net/DotNetZipHelp/html/24077057-63cb-ac7e-6be5-697fe9ce37d6.htm for more details
                    zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                }*/
                // Construct the contents of the README.txt file that will be included in this ZIP
                var readMeMessage = string.Format("Your ZIP file {0} contains the following files:{1}{1}", downloadFileName, Environment.NewLine);
                // Add the checked files to the ZIP
                foreach (ListItem li in cblFiles.Items)
                    if (li.Selected)
                    {
                        // Record the file that was included in readMeMessage
                        readMeMessage += string.Concat("\t* ", li.Text, Environment.NewLine);
                        // Now add the file to the ZIP (use a value of "" as the second parameter to put the files in the "root" folder)
                        zip.AddFile(li.Value, "Your Files");
                    }
                // Add the README.txt file to the ZIP
                //zip.AddEntry("README.txt", readMeMessage, Encoding.ASCII);
                // Send the contents of the ZIP back to the output stream
                zip.Save(Response.OutputStream);</pre></code>
I'm not sure how to get the downloads to point to my application directory,I tried everything I can think off.
