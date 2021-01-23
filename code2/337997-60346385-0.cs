    using System.ComponentModel.DataAnnotations;
    public class Material
    {
        [Required]
        [NonEmptyGuid]
        public Guid Guid { get; set; }
    }
