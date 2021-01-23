    if (i > 0)
        {
                      HttpPostedFileBase file = Request.Files["Image"];
                       
                        if (file != null && file.ContentLength > 0)
                        {
                            if (!string.IsNullOrEmpty(file.FileName))
                            {
                                string extension = Path.GetExtension(file.FileName);
                                switch ((extension.ToLower()))
                                {
                                    case ".doc":
                                        break;
                                    case ".docx":
                                        break;
                                    case ".pdf":
                                        break;
                                    default:
                                        ViewBag.result = "Please attach file with extension .doc , .docx , .pdf";
                                        return View();
                                }
                                if (!Directory.Exists(Server.MapPath("~") + "\\Resume\\"))
                                {
                                    System.IO.Directory.CreateDirectory(Server.MapPath("~") + "\\Resume\\");
                                }
                                string documentpath = Server.MapPath("~") + "\\Resume\\" + i + "_" + file.FileName;
                                file.SaveAs(documentpath);
                                string filename = i + "_" + file.FileName;
                                result = _objbalResume.UpdateResume(filename, i);
                                Attachment at = new Attachment(documentpath);
                              
                        
    //ViewBag.result = (ans == true ? "Thanks for contacting us.We will reply as soon as possible" : "There is some problem. Please try again later.");
                            }
                        }
                        else
                        {
                          ....
                        }
                    }
