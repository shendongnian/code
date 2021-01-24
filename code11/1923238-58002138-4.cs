    public class MyData {
      [Required]
      [StringLength(9)]
      [Display(Name="Id:")]
      public string ticketIdAppliInput {get;set;}
      [Required]
      public string ticketNameAppliInput {get;set;}
      [Required]
      public string ticketEmailAppliInput {get;set;}
    }
