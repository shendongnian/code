 lang-cs
Task.Run(async ()=>
{
   await MyApiCall();
   using (var scope = CreateDiScope())
   {
       var ctx = scope.ServiceProvider.GetService<MyDbContext>();
       ....
       ctx.SaveChanges()
   }
}
 
