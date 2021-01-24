    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    
    namespace ImageCrop.Controllers
    {
        public class HomeController : Controller
        {
            private readonly IHostingEnvironment _hostingEnv;
            public HomeController(IHostingEnvironment hostingEnv)
            {
                _hostingEnv = hostingEnv;
            }
            public IActionResult ImageCrop()
            {
                return View();
            }
            private bool IsValidExtension(IFormFile filename)
            {
                bool isValid = false;
                Char delimiter = '.';
                string fileExtension;
                string[] imgTypes = new string[] { "png", "jpg", "gif", "jpeg" };
                string[] documentsTypes = new string[] { "doc", "docx", "xls", "xlsx", "pdf", "ppt", "pptx" };
                string[] collTypes = new string[] { "zip", "rar", "tar" };
                string[] VideoTypes = new string[] { "mp4", "flv", "mkv", "3gp" };
                fileExtension = filename.FileName.Split(delimiter).Last();
                // fileExtension = substrings[substrings.Length - 1].ToString();
                int fileType = 0;
                if (imgTypes.Contains(fileExtension.ToLower()))
                {
                    fileType = 1;
                }
                else if (documentsTypes.Contains(fileExtension.ToLower()))
                {
                    fileType = 2;
                }
                else if (collTypes.Contains(fileExtension.ToLower()))
                {
                    fileType = 3;
                }
                else if (VideoTypes.Contains(fileExtension.ToLower()))
                {
                    fileType = 4;
                }
                switch (fileType)
                {
                    case 1:
                        if (imgTypes.Contains(fileExtension.ToLower()))
                        {
                            isValid = true;
                        }
                        break;
                    case 2:
                        if (documentsTypes.Contains(fileExtension.ToLower()))
                        {
                            isValid = false;
                        }
                        break;
                    case 3:
                        if (collTypes.Contains(fileExtension.ToLower()))
                        {
                            isValid = false;
                        }
                        break;
                    case 4:
                        if (VideoTypes.Contains(fileExtension.ToLower()))
                        {
                            isValid = true;
                        }
                        break;
                    default:
                        isValid = false;
                        break;
                }
                return isValid;
            }
            private string GetNewFileName(string filenamestart, IFormFile filename)
            {
                Char delimiter = '.';
                string fileExtension;
                string strFileName = string.Empty;
                strFileName = DateTime.Now.ToString().
                    Replace(" ", string.Empty).
                    Replace("/", "-").Replace(":", "-");
                fileExtension = filename.FileName.Split(delimiter).Last();
                Random ran = new Random();
                strFileName = $"{ filenamestart}_{ran.Next(0, 100)}_{strFileName}.{fileExtension}";
                return strFileName;
            }
            public IActionResult UploadFilesWihtLocation()
            {
                string hoststr = _hostingEnv.WebRootPath;
    
                string[] strFileNames;
                ///string url = "";
                try
                {
                    long size = 0;
                    var files = Request.Form.Files;
                    strFileNames = new string[files.Count];
                    string fileLocation = Request.Form["UploadLocation"].ToString();
                    //string[] path = fileLocation.Split("/");
                    string fileInitals = Request.Form["FileInitials"].ToString();
                    int i = 0;
                    string[] path = fileLocation.Split("\\");
                    if (!Directory.Exists(hoststr + "\\" + path[1]))
                    {
                        Directory.CreateDirectory(hoststr + "\\" + path[1]);
                        Directory.CreateDirectory(hoststr + "\\" + path[1] + "\\" + path[2]);
                    }
                    else if (!Directory.Exists(hoststr + fileLocation))
                    {
                        Directory.CreateDirectory(hoststr + "\\" + path[1] + "\\" + path[2]);
                    }
                    foreach (var file in files)
                    {
                        if (IsValidExtension(file))
                        {
                            var filename = GetNewFileName(fileInitals + i, file);
                            strFileNames[i] = fileLocation + filename;
                            string fullpath = hoststr + fileLocation + $@"\{filename}";
                            size += file.Length;
                            using (FileStream fs = System.IO.File.Create(fullpath))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                                fs.Close();
                            }
                        }
                        else
                        {
                            strFileNames = new string[1];
                            strFileNames[0] = "Invalid File";
                        }
                        i = i + 1;
                    }
                }
                catch (Exception ex)
                {
                    strFileNames = new string[1];
                    strFileNames[0] = ex.Message;
                }
                return Json(strFileNames);
            }
        }
    }
