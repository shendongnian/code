    [HttpPost("changeprojectstatus/{userId}/{projectId}")]
    public IActionResult ChangeProjectStatus(int userId, int projectId)
    {
        var project = _context.Projects.Where(x => x.Id == projectId);
        {
            // Make changes on entity
            var pr = project.FirstOrDefault(x => x.Status == ProjectStatus.Ready);
            pr.Status = ProjectStatus.Pending; //update the status
            // Update entity in DbSet
            _context.Projects.Update(pr);
            _context.SaveChanges();
        }
        if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();
        return Ok();
    }
