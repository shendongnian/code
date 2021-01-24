    [HttpPost("changeprojectstatus/{userId}/{projectId}")]
            public IActionResult ChangeProjectStatus(int userId, int projectId)
            {
                var result = _context.UserProjects.Where(x => x.UserId == userId && x.ProjectId == 
                                                                              projectId);
    
                if (result != null)
                {
                    // Make changes on entity
                    var pr = result.Where(x => x.Project.Status == ProjectStatus.Ready);
                    pr.Peoject.Status = ProjectStatus.Pending; //update the status
                    // Update entity in DbSet
                    _context.UserProjects.Update(pr);
                    _context.SaveChanges();
                }
    
    
                if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();
    
                return Ok();
            }
     
