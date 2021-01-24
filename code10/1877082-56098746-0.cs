    public class MyModel
    {
      [ModelBinder(Name = "id")]
      [StringLength(36, MinimumLength = 3)]
      [DisplayName("id")]
      public string Id {get; set;}
    }
