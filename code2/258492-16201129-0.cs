      public ActionResult Upload()
        {
            foreach (string file in Request.Files)
            {
            	var hpf = this.Request.Files[file];
            	if (hpf.ContentLength == 0)
            	{
            		continue;
            	}
    
            	string savedFileName = Path.Combine(
            		AppDomain.CurrentDomain.BaseDirectory, "PutYourUploadDirectoryHere");
            		savedFileName = Path.Combine(savedFileName, Path.GetFileName(hpf.FileName));
    
            	hpf.SaveAs(savedFileName);
            }
    
        ...
        }
