    void Main()
    {
       var tag1 = new Tag { Name = "tag1" };
       var tag2 = new Tag { Name = "tag2" };
       var tag3 = new Tag { Name = "tag3" };
       
    	var posts = new List<Post>
    	{	
    		new Post 
    		{
    			Name = "Post1",
    			Tags = new List<Tag> { tag1, tag3 }
    		},
    		new Post 
    		{
    			Name = "Post2",
    			Tags = new List<Tag> { tag2, tag3 }
    		}
    	};
    	
    	var tagList = new List<Tag> { tag1 };
    	
    	var q = posts.Where(x => x.Tags.Intersect(tagList).Any());
    
    	q.Dump();
    }
    
    public class Post 
    { 
      public int? Id {get;set;} 
      public string Name {get;set;} 
      public virtual ICollection<Tag> Tags {get;set;} 
    } 
    
    public class Tag 
    { 
      public int? Id {get;set;} 
      public string Name {get;set;} 
      public virtual ICollection<Post> Posts {get;set;} 
    } 
