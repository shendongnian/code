    public IActionResult SaveResult(yourType rn)
            {
                RandomNumbTable rand = new RandomNumbTable();
                rand.Number = rn;
                _context.Add(rand);
                _context.SaveChanges();
    
                return Ok();
            }
