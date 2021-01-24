c#
public void method(){
    var entities = context.Posts
             .AsNoTracking() //  <---- add this Method here
             .Where(/* something */).ToList();
    foreach (var entity in entities){
         var result = CriticalAPI(entity.Id);
         entity.Token = result;
    }
    context.SaveChanges();
}
You could alternatively create an ENTIRELY separate dbContext for Logs, and you would set and save that context.  
