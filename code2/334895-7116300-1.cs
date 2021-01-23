    public class MyDTO
    {
       String Name { get; set; }
       String Id { get; set; }
       String ClassName { get; set; }
       int Number { get; set; }
    }
    var MyDTO = new MyDTO() 
    {
       Name      = Name,
       Id        = Id,
       ClassName = ClassName,
       Number    = Number
    }
    var stream = new StreamStructure(MyDTO) 
