        public class CaseInfo :IValidatableObject {        
    public virtual Guid Id { get; set; }     
    public virtual DateTime? ReferralDate { get; set; }     
    public virtual int Decision { get; set; } 
    public virtual string Reason { get; set; }     
    public virtual DateTime? StartDate { get; set; }     
    public virtual DateTime? EndDate { get; set; }      
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)     {         throw new NotImplementedException();     }
 
