    var watchOne = System.Diagnostics.Stopwatch.StartNew();
    testOne();
    watchOne.Stop();
    var resOne = watchOne.ElapsedMilliseconds;
    
    var watchTwo = System.Diagnostics.Stopwatch.StartNew();
    testTwo();
    watchTwo.Stop();
    var resTwo= watchTwo.ElapsedMilliseconds;
       
    public void testOne(){
        var users = _context.Users.Include(p => p.Photos)
        .Where(p => p.Photos.Any())
        .AsQueryable();
    }
    public void testTwo(){
        var users = _context.Users.Include(p => p.Photos)
        .Where(p => p.HasPhoto == true) 
        .AsQueryable();
    }
