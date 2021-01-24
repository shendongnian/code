    [HttpPost("changeprojectstatus/{userId}/{projectId}")]
            public IActionResult ChangeProjectStatus(int userId, int projectId)
            {
                var result = _context.UserProjects.First(x => x.UserId == userId && x.ProjectId == 
                                                                              projectId).Select(up => up.Project);
    
                if (result != null)
                {
                    // Make changes on entity
                    var pr = result.FirstOrDefault(x => x.Status == ProjectStatus.Ready);
                    pr.Status = ProjectStatus.Pending; //update
                    // Update entity in DbSet
                    _context.Projects.Update(pr);
                    _context.SaveChanges();
                }
    
    
                if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();
    
                return Ok();
            }
