    public class MyDTO {
        string p1 {get; set;}
        int p2 {get; set;}
        //...
    }
    var employees = ctx.Database.SqlQuery<MyDTO>(@"
        select someString as p1, someInt as p2 from employee").ToList();
