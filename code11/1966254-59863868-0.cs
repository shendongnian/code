    public class Folder
    {
        // one folder contain a list of folder
        [XmlElement(ElementName = "Folder")]
        public List<Folder> Folders { get; set; }
        // a folder as a name
        [XmlAttribute("name")]
        public string Name { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb, 0);
            return sb.ToString();
        }
        private void ToString(StringBuilder sb, int level)
        {
            const int indent = 2;
            sb.Append(new string(' ', level * indent));
            sb.AppendLine(Name);
            foreach (var folder in Folders)
                folder.ToString(sb, level + 1);
        }
    }
