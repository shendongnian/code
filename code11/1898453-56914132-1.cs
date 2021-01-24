    public static async Task Initialize(IServiceProvider serviceProvider) {
      using (var context = new ApplicationDbContext(
    				serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
    			{
    				if (!context.Posts.Any())
    				{
    					post.Comments = comments;
    
    					await SeedPost(context);
    				}
    			}
    }
