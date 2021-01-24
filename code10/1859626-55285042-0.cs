    public class Contact
    {
        /// <summary>
        /// Unique identifier of the contact.
        /// </summary>
        public string ContactId { get; set; }
    
        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        public string Name { get; set; }
    
        /// <summary>
        /// Defines whether the contact belongs to another contact (e.g.,
        /// parents, organization).
        /// </summary>
        [ForeignKey("BelongsToContact")]
        public int? BelongsToContactId { get; set; }
        public virtual Contact BelongsToContact { get; set; }
    }
