    public class Folder
    {
        /// <summary>
        /// List of folders in the folder
        /// </summary>
        [XmlElement(ElementName = "Folder")]
        public List<Folder> Folders { get; set; }
        /// <summary>
        /// Name of the folder
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
        /// <summary>
        /// Access information of the folder
        /// </summary>
        [XmlAttribute("access")]
        public string Access { get; set; }
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
            sb.AppendLine($"{Name} ({Access})");
            foreach (var folder in Folders)
                folder.ToString(sb, level + 1);
        }
    }
