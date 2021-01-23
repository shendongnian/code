    public class ListDto
    {
       public int Id {get;set;}
       public RecipientCountDto RecipientCount {get;set;}
       public RecipientCountDto SomeOtherName {get;set;}
    }
    
    public class RecipientCountDto
    {
       public int Total {get;set;}
       public int Active {get;set;}
    }
