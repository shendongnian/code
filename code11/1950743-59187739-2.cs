    For example, you could inject an `IWebHostEnviroment` instance in the controller:
    <pre>
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public HomeController(<b>IWebHostEnvironment env</b>)
        {
            <b>this._env = env;</b>
        }
        public IActionResult Privacy()
        {
            <b>var dir = Path.Combine( this._env.ContentRootPath, @"MM\VM\VM DB\nv - master\nvd");</b>
            string[] filesnumber = Directory.GetFiles(dir, "*.json");
            foreach (string filename in filesnumber)
            {
                var jsonFull = System.IO.File.ReadAllText(filename);
                ...
            }
            return Ok("hello,world");
         }
    }
    </pre>
