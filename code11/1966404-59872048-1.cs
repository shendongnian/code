     public async Task<IActionResult> OnPost(int id)
     {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Incident = await _context.Incidents.Include(i=>i.Comments).FirstAsync(i => i.Id == id);
            
            NewComment.EnterDateTime = DateTime.Now;
            Incident.Comments.Add(NewComment);
            await _context.SaveChangesAsync();
            return Page();
      }
