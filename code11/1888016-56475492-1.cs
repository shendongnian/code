    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "data")]
    public class Person
    {
       public int pId {get; set;}
       public string PName {get; set;}
       public School schoolAttended {get; set;}
       public IFormFile File { get; set; }
    }
