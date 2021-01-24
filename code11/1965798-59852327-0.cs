public void ConfigureServices(IServiceCollection services)
{
   services.AddMvc();
   services.AddNodeServices();
}
Add constructor in the Controller
public class HomeController : Controller
    { 
        private readonly INodeServices _nodeServices;
        public HomeController(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }
Call NodeServices as shown below
public async Task<IActionResult> About()
{
  var msg = await nodeServices.InvokeAsync<string>(“./hello.js”,1);
  return View();
}
Add following code to js file
module.exports = function (callback)
{
  var message = ‘Hello world’;
  callback(null, message);
};
