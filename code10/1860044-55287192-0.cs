    public class BaseNode
    {
        [JsonIgnore]
        public const string _constKeyName_sNodeParentId = "parentid";
        [JsonProperty(PropertyName = "id", Required = Required.DisallowNull)]
        public string _sNodeId { get; set; }
        [DisplayName("Parent Folder")]
        [DefaultValue("000000000000000000000000")]
        [MaxLength(24)]
        [MinLength(24)]
        public virtual string _sNodeParentId { get; set; }
    }
