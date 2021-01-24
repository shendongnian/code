    public ActionResult GetFiles(string LogPath)
            {
                DirectoryInfo _directoryInfo = _directoryInfo = new DirectoryInfo(LogPath);
    
                List<SelectListItem> _lstLogFiles = new List<SelectListItem>();
                string _ErrorLogFileExtensions = Functions.GetConfigValue(ArchiveConstants.ErrorLogFileExtensions);
    
                string[] _ErrorLogFileExtensionsArr = !string.IsNullOrEmpty(_ErrorLogFileExtensions) ? _ErrorLogFileExtensions.ToLower().Split(',') : new string[0];
                if (_directoryInfo.Exists)
                {
                    foreach (FileInfo _file in _directoryInfo.GetFiles().OrderByDescending(x => x.CreationTime))
                    {
                        if (_ErrorLogFileExtensionsArr.Contains(_file.Extension))
                            _lstLogFiles.Add(new SelectListItem { Text = Path.GetFileNameWithoutExtension(_file.Name), Value = _file.Name });
    
                    }
                }
                return Json(_lstLogFiles, JsonRequestBehavior.AllowGet);
            }
