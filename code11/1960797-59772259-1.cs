    [HttpPost]
    public async Task<IActionResult> UploadVideo(VideoViewModel video, IFormFile file)
    {
        if (file.Length > 0)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
                string userName = (User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name).Value);
                string folder = Path.Combine(_environment.WebRootPath, "video");
                string url = @"\video\" + userName + @"\" + file.FileName;
                string pathString = Path.Combine(folder, userName);
                if (!Directory.Exists(pathString))
                {
                    Directory.CreateDirectory(pathString);
                }
                var filePath = Path.Combine(pathString, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    _videoLogic.SaveVideo(new Video(userId, video.VideoId, video.Description, file.FileName, DateTime.Now, url, video.CategoryId));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR: " + ex.Message.ToString();
            }
        }
        else
        {
            ViewBag.Message = "You have not specified a file.";
        }
        return RedirectToAction("UploadVideo");
    }
