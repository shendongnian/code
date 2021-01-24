     public class EditModel : PageModel
    {
        private readonly ChangeUploadedImage.Data.MyDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public EditModel(MyDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }
        [BindProperty]
        public Post Post { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.Image != null)
            {
                var path = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/uploads", Post.FeatureImage);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = GetUniqueName(this.Image.FileName);
                var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/uploads");
                var filePath = Path.Combine(uploads, fileName);
                this.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                this.Post.FeatureImage = fileName;
            }
            _context.Attach(Post).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.PostID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
