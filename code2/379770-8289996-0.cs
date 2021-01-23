    namespace OperationsMetrics
    {
    [MetadataType(typeof(ClientStatMD))]
    public partial class client_wkly_stat : IValidatableObject
    {
        public class ClientStatMD
        {
            [Required(ErrorMessage = "Client selection is required")]
            public virtual int client_id { get; set; }
            [Required(ErrorMessage = "SLAs met is required")]
            public virtual int wkly_sla_met { get; set; }
            [Required(ErrorMessage = "Total SLAs possible is required")]
            public virtual int wkly_sla_req { get; set; }
            [Required(ErrorMessage = "Number of input files is received")]
            public virtual int num_inp_files_rec { get; set; }
            [Required]
            public string client_name { get; set; } 
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (wkly_sla_met > wkly_sla_req)
            {
                yield return new ValidationResult("SLAs met cannot be greater that SLAs possible");
            }
        }
        public string client_name { get; set; } //this isn't a part of the actual db object but can still be accessed in the Validate method
    }
