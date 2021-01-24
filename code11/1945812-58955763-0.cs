    public class MyItem
    { 
       public MyItem {}
       public string Item1 {get; set;}
       public int Item2 {get; set;}
    }
    
    and then 
    
     await Http.GetJsonAsync<List<MyItem>>(...)
