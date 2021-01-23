        try
        {
            Package package;
            string strTemplateName = ddl_Templates.SelectedValue.ToString(); //Select Dotx template 
            string strClaimNo = "3284112";
            string strDatePart = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            //Word template file
            string templateName = Server.MapPath("~\\LetterTemplates\\" + strTemplateName + ".dotx");
            PackagePart documentPart = null;
            //New file name to be generated from 
            string docFileName = Server.MapPath("~\\LetterTemplates\\" + strClaimNo + "_" + strTemplateName + "_" + strDatePart + ".docx");
            File.Copy(templateName,docFileName, true);
            string fileName = docFileName;
            package = Package.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
            DataSet DS = GetDataSet(strClaimNo, ""); // to get the data from backend to fill in for merge fields
            try
            {
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (System.IO.Packaging.PackageRelationship documentRelationship
                                in package.GetRelationshipsByType(documentRelationshipType))
                            {
                                NameTable nt = new NameTable();
                                nsManager = new XmlNamespaceManager(nt);
                                nsManager.AddNamespace("w",
                                  "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
                                Uri documentUri = PackUriHelper.ResolvePartUri(
                                  new Uri("/", UriKind.Relative), documentRelationship.TargetUri);
                                documentPart = package.GetPart(documentUri);
                                //Get document xml
                                XmlDocument xdoc = new XmlDocument();
                                xdoc.Load(documentPart.GetStream(FileMode.Open, FileAccess.Read));
                                int intMergeFirldCount = xdoc.SelectNodes("//w:t", nsManager).Count;
                               
                                XmlNodeList nodeList = xdoc.SelectNodes("//w:t", nsManager);
                                foreach (XmlNode node in nodeList)
                                {
                                    try
                                    {
                                        xdoc.InnerXml = xdoc.InnerXml.Replace(node.InnerText, DS.Tables[0].Rows[0][node.InnerText.Replace("«", "").Replace("»", "").Trim()].ToString());
                                    }catch(Exception x) { }
                                }
                                StreamWriter streamPart = new StreamWriter(documentPart.GetStream(FileMode.Open, FileAccess.Write));
                                xdoc.Save(streamPart);
                                streamPart.Close();
                                package.Flush();
                                package.Close();
                            }
                            using (WordprocessingDocument template = WordprocessingDocument.Open(docFileName, true))
                            {
                                template.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
                                template.MainDocumentPart.Document.Save();
                            }
                            byte[] bytes = System.IO.File.ReadAllBytes(docFileName);
                            System.IO.File.Delete(docFileName);
                            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                            response.ClearContent();
                            response.Clear();
                            response.ContentType = "application/vnd.msword.document.12"; //"application/msword";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;
                            response.AddHeader("Content-Disposition", "attachment; filename=" + strClaimNo + "_" + strTemplateName + "_" + strDatePart + ".docx;");
                            response.BinaryWrite(bytes);
                            response.Flush();
                            response.Close();
                        }
                        else
                        {
                            throw (new Exception("No Records Found."));
                        }
                    }
                    else
                    {
                        throw (new Exception("No Records Found."));
                    }
                }
                else
                {
                    throw (new Exception("No Records Found."));
                }
            }
            catch (Exception ex)
            {
                package.Flush();
                package.Close();
                // Softronic to add code for exception handling
            }
        }
        catch (Exception ex)
        {
            // add code for exception handling
        }
        finally
        {
        }
    }
   
