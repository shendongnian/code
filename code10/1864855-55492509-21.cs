    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    class VisualStudioDataObject
    {
        public VisualStudioDataObject(IDataObject data)
        {
            if (data is null) {
                throw new ArgumentNullException("IDataObject data", "Invalid DataObject");
            }
            this.FileList = new List<FileObject>();
            GetData(data);
        }
        public List<FileObject> FileList { get; private set; }
        public string ProjectUUID { get; private set; }
        public string ProjectPath { get; private set; }
        public string ProjectFilePath { get; private set; }
        public string StartingObject { get; private set; }
        public class FileObject
        {
            public FileObject(string project, string path, string type) {
                this.SourceProject = project;
                this.FilePath = path;
                this.FileType = type;
            }
            public string SourceProject { get; }
            public string FilePath { get; }
            public string FileType { get; }
        }
        private void GetData(IDataObject data)
        {
            List<string> formats = data.GetFormats(false).ToList();
            if (formats.Count == 0) return;
            foreach (string format in formats)
            {
                switch (format)
                {
                    case "UnicodeText":
                        this.StartingObject = data.GetData(DataFormats.UnicodeText, true).ToString();
                        break;
                    case "VX Clipboard Descriptor Format":
                        var projectMS = (MemoryStream)data.GetData("VX Clipboard Descriptor Format", false);
                        projectMS.Position = 0;
                        string prjFile = Encoding.Unicode.GetString(projectMS.ToArray()).TrimEnd("\0".ToCharArray());
                        this.ProjectFilePath = prjFile;
                        this.ProjectPath = Path.GetDirectoryName(prjFile);
                        break;
                    case "CF_VSSTGPROJECTITEMS":
                        GetFileData((MemoryStream)data.GetData("CF_VSSTGPROJECTITEMS", false));
                        break;
                }
            }
        }
        private void GetFileData(MemoryStream ms)
        {
            string uuidPattern = @"\{(.*?)\}";
            string content = Encoding.Unicode.GetString(ms.ToArray());
            //Get the Project UUID and remove it from the data object
            var match = Regex.Match(content, uuidPattern, RegexOptions.Singleline);
            if (match.Success) {
                this.ProjectUUID = match.Value;
                content = content.Replace(this.ProjectUUID, "").Substring(match.Index);
                //Split the file list: Part1 => Project Name, Part2 => File name
                string[] projectFiles = content.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < projectFiles.Length; i += 2)
                {
                    string sourceFile = projectFiles[i + 1].Substring(0, projectFiles[i + 1].IndexOf("\0"));
                    this.FileList.Add(new FileObject(projectFiles[i], sourceFile, Path.GetExtension(sourceFile)));
                }
            }
            else
            {
                this.FileList = null;
                throw new InvalidDataException("Invalid Data content");
            }
        }
    }
