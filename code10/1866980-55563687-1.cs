    [HttpPost]
    [Route("api/Memes/AddMemes")]
    public IHttpActionResult CreateMemes([FromBody] MemHashTagsViewModel createMem)
    {
        ApplicationDbContext db = new ApplicationDbContext();
    
        if (createMem != null)
        {
            Memes mem = new Memes()
            {
                MemName = createMem.MemName,
                Image = createMem.Image,
                UserId = createMem.UserId
            };
    
            foreach (var item in createMem.HashTags)
            {
                var hashTag = new HashTag()
                {
                    Name = item
                };
                mem.HashTags.add(hashTag);
            }
            db.add(mem);
            
            db.SaveChanges();
            return Ok();
        }
        else
        {
            return  NotFound();
        }
    }
