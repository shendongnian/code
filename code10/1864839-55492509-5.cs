    using System;
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
        public List<FileObject> FileList { get; set; }
        public string ProjectUUID { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectFilePath { get; set; }
        public string StartingObject { get; set; }
        public class FileObject
        {
            public string SourceProject { get; set; }
            public string FilePath { get; set; }
            public string FileType { get; set; }
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
                        MemoryStream projectMS = (MemoryStream)data.GetData("VX Clipboard Descriptor Format", false);
                        projectMS.Position = 0;
                        string prjFile = Encoding.Unicode.GetString(projectMS.ToArray()).TrimEnd("\0".ToCharArray());
                        this.ProjectFilePath = prjFile;
                        this.ProjectPath = Path.GetDirectoryName(prjFile);
                        break;
                    case "CF_VSSTGPROJECTITEMS":
                        MemoryStream ms = (MemoryStream)data.GetData("CF_VSSTGPROJECTITEMS", false);
                        GetFileData((MemoryStream)data.GetData("CF_VSSTGPROJECTITEMS", false));
                        break;
                }
            }
        }
        private void GetFileData(MemoryStream ms)
        {
            string uuidPattern = @"\{(.*?)\}";
            string content = Encoding.Unicode.GetString(ms.ToArray());
            //Get the Project UUID and revove it from the data object
            Match match = Regex.Match(content, uuidPattern, RegexOptions.Singleline);
            if (match.Success) this.ProjectUUID = match.Value.ToString();
            content = content.Replace(this.ProjectUUID, "").Substring(match.Index);
            //Split the file list: Part1 => Project Name, Part2 => File name
            string[] projectFiles = content.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0;  i < projectFiles.Length; i +=2)
            {
                string sourceFile = projectFiles[i + 1].Substring(0, projectFiles[i + 1].IndexOf("\0"));
                this.FileList.Add(new FileObject() {
                    SourceProject = projectFiles[i],
                    FilePath = sourceFile,
                    FileType = Path.GetExtension(sourceFile)
                });
            }
        }
    }
