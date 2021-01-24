public class Entity
{
        public String id { private get; set; }
        [JsonProperty("code")]
        public String Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.IdDuplicate = value;
            }
        }
    public String IdDuplicate { get; set; }
}
