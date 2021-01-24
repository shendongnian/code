    var UserImgBinder = new UserImgBinder
    {
        User = _context.User.Where(x => x.UserId.Equals(id)).FirstOrDefault(),
        ImageUpload = new List<IFormFile> {
                    file
                }
    };
