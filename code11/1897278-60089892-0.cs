public void ConfigureServices(IServiceCollection services)
{
  services
    .AddGraphQL(o => o.ExposeExceptions = true)
    .AddGraphTypes(ServiceLifetime.Scoped);
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  app.UseDeveloperExceptionPage();
  app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());  // CORS settings
  app.UseRouting();
  app.UseEndpoints(o => o.MapControllers());
  
  app.UseGraphQLPlayground(new GraphQLPlaygroundOptions 
  { 
    GraphQLEndPoint = "/services/queries/groups"  // default GraphQL endpoint  
  });
}
**If GQL playground still doesn't hit your controller, try dynamic parameter**
[HttpPost]
[Route("services/queries/groups")]
public async Task<dynamic> Items([FromBody] dynamic queryParams)
{
  var schema = new Schema
  {
    Query = new GroupsQuery() // create query and populate it from dynamic queryParams
  };
  var response = await schema.ExecuteAsync(o =>
  {
    //o.Inputs = queryParams.variables;
    o.Query = queryParams.query;
    o.OperationName = queryParams.operationName;
    o.UserContext = new Dictionary<string, dynamic>();
    o.ValidationRules = DocumentValidator.CoreRules;
    o.ExposeExceptions = true;
    o.EnableMetrics = true;
  });
  return response;
}
