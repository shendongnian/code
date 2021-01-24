    class AvatarsController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userID=SomehowFindTheCurrentUserID();
            var avatarPath= Path.Combine(_avatarRoot,$"{userID}.jpeg");
            return File(avatarPath, "image/jpeg");
        }
    } 
