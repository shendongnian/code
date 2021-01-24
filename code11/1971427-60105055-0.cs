var appFactory = new WebApplicationFactory<StartupAutomatedTesting>()
   .WithWebHostBuilder(builder =>
   {
       ... etc ...
   });
using (var scope = appFactory.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    context.Database.EnsureCreated();
    context.Pets.AddRange(fakePet);
    context.SaveChanges();
}
var testingClient = appFactory.CreateClient();
... etc ...
