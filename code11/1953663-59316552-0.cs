        [Table(name: "ChannelTypeT")]
        public class ChannelTypeT
        {
            [StringLength(02)]
            public string Lang { get; set; }
            public string Text { get; set; }
            #region Primary Key derived from Foreign key for Config tabels        
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            [ForeignKey(name: "ChannelType")]
            public string ChannelTypeId { get; set; }
            public virtual ChannelType ChannelType { get; set; }
            #endregion
        }
