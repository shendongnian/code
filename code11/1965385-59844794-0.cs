     $("#btnEmailTest").on("click", function () {
                $.ajax({
                    type: "POST",
                    url: '@Url.Action("Testemail2", "Service")',
                    contentType: "application/json",
                    success: function (data) {
                        //window.location
                        alert("success : " + data);
                    },
                    error: function (xhr, status, error) {
                        //alert("Error " + xhr.responseText + " \n " + error);
                    }
                })
            });
     [HttpPost]
            public ActionResult Testemail2()
            {
                string senderEmail = "testc@send.com";
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(senderEmail);
                mailMessage.To.Add("testTo@to.com");
                mailMessage.Subject = "Test EML Subject012";
                mailMessage.Body = "Test EML Body012";
                /// mark as DRAFT
                mailMessage.Headers.Add("X-Unsent", "1");
                //ATTACHMENTS
                var stream = new MemoryStream();
                EML_Stream(mailMessage, stream, senderEmail);
                stream.Position = 0;
                string variable = "";
                if(TempData["rootTest"] != null)
                {
                    variable = TempData["rootTest"].ToString();
                }
                return Json(variable);
                //return File(stream, "message/rfc822", "Test_Email.eml");
            }
            private void EML_Stream(MailMessage msg, Stream str, string fromEmail)
            {
                string rootTemp = "";
                using(var client = new SmtpClient())
                {
                    try
                    {
                        string timeNow = DateTime.Now.ToString("MM-dd-yyyy-HHmmss");
                        var tempfolder = Path.Combine(Path.GetTempPath(), Assembly.GetExecutingAssembly().GetName().Name);
                        //tempfolder = Path.Combine("MailTest");
                        // Create temp folder to hold .eml file
                        tempfolder = Path.Combine(tempfolder, timeNow);
                        if (!Directory.Exists(tempfolder))
                        {
                            Directory.CreateDirectory(tempfolder);
                        }
                        rootTemp = tempfolder;
                        TempData["rootTest"] = rootTemp;
                    client.UseDefaultCredentials = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    client.PickupDirectoryLocation = tempfolder;
                    client.Send(msg);
    
    
                    }
                    catch (System.Exception ex)
                    {
                        TempData["Error"] = ex.Message.ToString();
                    }
    
                    // C:/temp/maildrop should contain .eml file.
                    ///C:\temp\maildrop\
                    //var filePath = Directory.GetFiles("C:\\temp\\maildrop\\").Single();
                    string filePath = Directory.GetFiles(rootTemp).Single();
                    /// Create new file and remove all lines with 'X-Sender:' or 'From:'
                    string newFile = Path.Combine(rootTemp, "testemlemail.eml");
                    using (var reader = new StreamReader(filePath))
                    {
                        using (var writer = new StreamWriter(newFile))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (!line.StartsWith("X-Sender:") &&
                                   !line.StartsWith("From:") &&
                                    !line.StartsWith("X-Receiver: " + fromEmail) &&
                                    !line.StartsWith("To: " + fromEmail))
                                {
                                    writer.WriteLine(line);
                                }
                            }
                        }
                    }
                    using(var fs = new FileStream(newFile, FileMode.Open))
                    {
                        fs.CopyTo(str);
                    }
                }
            }
