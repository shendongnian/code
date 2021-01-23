HttpRequest request = HttpContext.Current.Request;
// get the physical path to the web application
string appPath = request.MapPath(request.ApplicationPath);
string directory = System.IO.Path.Combine(appPath, "DownloadLibrary/");
// Get the list of files into the CheckBoxList
var dirInfo = new DirectoryInfo(directory);
cblFiles.DataSource = dirInfo.GetFiles();
cblFiles.DataBind();
