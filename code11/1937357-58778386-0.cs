    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        public ImageController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public FileContentResult ShowImage()
        {
            string fileName = Path.Combine(_appEnvironment.WebRootPath, "images\\avatar.png").Replace("\\", "/");
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return File(imageData, "image/png");
        }
    }
