    public IActionResult FileList()
    {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _context.UploadFile.Where(f => f.UserId == userId).ToList();
            return View(model);
    }
