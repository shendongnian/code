    public readonly ApplicationDbContext _context;
    public HomeController( ApplicationDbContext context)
    {
         _context = context;
    }
    [HttpPost]
        public ActionResult AddCar(Car model, IFormFile file)
        {
            Car c = new Car();
            c.Name = model.Name;
            c.Mileage = model.MileAge;
            _context.Car.Add(c);
            _context.SaveChanges();
            // Get Inserted Id;
            int id = c.CarId;
            
            // Create necessary directories 
            var originalDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Uploads");
            // different image folder
            var pathString1 = Path.Combine(originalDirectory.ToString(), "CarsImage");
            var pathString2 = Path.Combine(originalDirectory.ToString(), "CarsImage\\" + id.ToString());
            var pathString3 = Path.Combine(originalDirectory.ToString(), "CarsImage\\" + id.ToString() + "\\Thumbs");
            var pathString4 = Path.Combine(originalDirectory.ToString(), "CarsImage\\" + id.ToString() + "\\Gallery");
            // Check if directory exist, if not then create them
            if (!Directory.Exists(pathString1))
                Directory.CreateDirectory(pathString1);
            if (!Directory.Exists(pathString2))
                Directory.CreateDirectory(pathString2);
            if (!Directory.Exists(pathString3))
                Directory.CreateDirectory(pathString3);
            if (!Directory.Exists(pathString4))
                Directory.CreateDirectory(pathString4);
            // Check if file was uploaded
            if (file != null && file.Length > 0)
            {
                // Get file extension
                string ext = file.ContentType.ToLower();
                // Verify extension
                if (ext != "image/jpg" &&
                    ext != "image/jpeg" &&
                    ext != "image/pjpeg" &&
                    ext != "image/gif" &&
                    ext != "image/x-png" &&
                    ext != "image/png")
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        model.Categories = new SelectList(db.Category.ToList(), "CategoryId", "CategoryName");
                        model.Mileages = new SelectList(db.MileAge.ToList(), "MileAgeId", "Mile");
                        ModelState.AddModelError("", "The image was not uploaded - Wrong image extension");
                        return View();
                    }
                }
                // Init image name
                string imageName = file.FileName;
                // Save image name to Car table
                 Car dto = _context.Car.Find(id);
                 dto.ImageName = imageName; 
                 _context.SaveChanges();
                // Set Original and image paths
                var filePath = Path.Combine(pathString2, imageName);
                var filePath2 = Path.Combine(pathString3, imageName);
                // Save Original
                file.CopyTo(new FileStream(filePath, FileMode.Create));
                // Create and save thumb
                Stream stream = file.OpenReadStream();
                Image newImage = GetReducedImage(200, 200, stream);
                newImage.Save(filePath2);
            }
            return View();
        }
        public Image GetReducedImage(int width, int height, Stream resourceImage)
        {
            try
            {
                Image image = Image.FromStream(resourceImage);
                Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                return thumb;
            }
            catch (Exception e)
            {
                return null;
            }
        }
