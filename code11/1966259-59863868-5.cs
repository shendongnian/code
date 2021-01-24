    public class Container
    {
        /// <summary>
        /// List of folders in the container
        /// </summary>
        [XmlElement(ElementName = "Folder")]
        public List<Folder> Folders { get; set; }
        /// <summary>
        /// Revision of the container
        /// </summary>
        [XmlAttribute("rev")]
        public string Revision { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Container rev: {Revision}");
            foreach (var folder in Folders)
                sb.AppendLine(folder.ToString());
            return sb.ToString();
        }
    }
