    public class PdfCreator : ICreator // Not best naming :)
    {
        public byte[] Create(string data) // Or you could pass your own class, dictionary, etc...
        {
            // Your PDF creation logic from public ActionResult CreateDocument()
        }
    }
    // To easily test and inject
    public interface ICreator
    {
        byte[] Create(string data);
    }
	
	// And in you Controller class
	public class HomeController : Controller
	{
		private readonly ICreator _pdfCreator = null;
		
		public HomeController(ICreator creator)
		{
			// You will receive it here from Dependency Injection framework or just initialize
			_pdfCreator = creator ?? new PdfCreator();
		}
		
		// Use it
		public ActionResult CreateDocument()
		{
			byte[] pdf = _pdfCreator.Create("My specific text");
			// Your logic goes here
		}
	}
