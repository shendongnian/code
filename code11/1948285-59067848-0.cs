    [HttpGet("{userId}/{projectId}")]
    public IActionResult GetProjectByUserId(int userId, int projectId)
    {
        var project = from up in _context.UserProjects
            where up.UserId == userId
            select new
            {
                UserName = up.User.Username,
                ProjectName = up.Project.Name
            };
        return Ok(project);
    } 
