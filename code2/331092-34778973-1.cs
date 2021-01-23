    public bool CompareByModifiedDate(string strOrigFile, string strDownloadedFile)
		{
		     DateTime dtOrig = DateTime.Parse(File.GetLastWriteTime(strOrigFile).ToString("MM/dd/yyyy hh:mm:ss"));
		     DateTime dtNew = DateTime.Parse(File.GetLastWriteTime(strDownloadedFile).ToString("MM/dd/yyyy hh:mm:ss"));
		
		     if (dtOrig == dtNew)
		        return true;
		     else
		        return false;
		}
