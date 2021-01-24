    public class GetImagesController : Controller
    {
        private readonly IWebHostEnvironment _host;
        public GetImagesController(IWebHostEnvironment host)
        {
            _host = host;
        }
        [HttpGet("{images}")]
        public async Task<List<byte[]>> Get([FromQuery]string images)
        {
            List<byte[]> imageBytes = new List<byte[]>();
            String[] strArray = images.Split(',');
            for (int i = 0; i < strArray.Length; i++)
            {
                String filePath = Path.Combine(_host.ContentRootPath, "images", strArray[i]+".jpg");
                byte[] bytes =  System.IO.File.ReadAllBytes(filePath);
                imageBytes.Add(bytes);
            }
            return imageBytes;
        }
    }
