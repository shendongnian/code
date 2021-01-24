    public Managment GetData(int managmentId){
        var data = context.Management
           .Include(u => u.Users)
           .Include(b => b.Books)
           .FirstOrDefault(m => m.Id == managmentId); 
     }
