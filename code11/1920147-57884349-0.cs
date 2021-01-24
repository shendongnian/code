    // user class
    public partial class tempu
    {
    	public int id { get; set; }
    	[StringLength(50)]
    	public string name { get; set; }
    	public List<tempd> tempds { get; set; }
    }
    
    // device class
    public partial class tempd
    {
    	public int? token { get; set; }
    	public int? uid { get; set; }
    	[StringLength(50)]
    	public string name { get; set; }
    	public int id { get; set; }
    	public tempu tempus { get; set; }
    }
    
    // context
    modelBuilder.Entity<tempu>(entity =>
    {
    	entity.ToTable("tempu");
    });
    
    //// this is do the mapping of one to many
    modelBuilder.Entity<tempd>(entity =>
    {
    	entity.ToTable("tempd")
    	.HasOne(p => p.tempus)
    	.WithMany(i => i.tempds)
    	.HasForeignKey(b => b.uid);
    });
    
    // linq query
    var results = _context.tempu
    	  .Where(t => t.tempds.Any(y => y.token == null)) //// this will check if device id can be null in any case, 
    	  .Include(s => s.tempds) //// this will do the join
    	  .ToList();
    
    // generated sql
    SELECT [t].[id], [t].[name]
    FROM [tempu] AS [t]
    WHERE EXISTS (
        SELECT 1
        FROM [tempd] AS [y]
        WHERE [y].[token] IS NULL AND ([t].[id] = [y].[uid]))
    ORDER BY [t].[id] 
