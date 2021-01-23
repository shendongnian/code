    [DataContract]
    public class NewspaperDTO
    {
        public NewspaperDTO(Newspaper newspaper)
        {
            this.Name = newspaper.Name;
            this.Image = newspaper.Image;
            this.Link = newspaper.Link;
            this.Encoding = newspaper.Encoding;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Encoding { get; set; }
    }
