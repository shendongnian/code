public void UpdateCategory(Category category) 
{ 
	using (var Context = new AppDbContext()) 
	{ 
		Context.Entry(category).State = System.Data.Entity.EntityState.Modified; 
        Context.SaveChanges(); 
	}
}
-> you use two different `DbContext`'s together (which can cause problems with change tracking)!  
**Solution:**
Try to use DependencyInjection for all `DbContext`'s instead of creating them locally to prevent problems with change tracking.
