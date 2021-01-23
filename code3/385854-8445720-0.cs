    public class YourController : Controller
    {
        [HttpGet]
        public ImageResult GetImage(int whatever)
        {
            stream imageStream = yourJpgFactory.GetImage(whatever)
            return (imageStream)
        }
    }
