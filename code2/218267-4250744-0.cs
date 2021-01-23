    public class Repository
	{
		public List<Author> GetAuthors()
		{
			var authors = new List<Author>
			              	{
			              		new Author{Name = "Author 1"},
								new Author{Name = "Author 2"},
								new Author{Name = "Author 1"}
			              	};
			return authors.Distinct(new CustomComparer<Author>()).ToList();
		}
		public List<BlogPost> GetBlogPosts()
		{
			var blogPosts = new List<BlogPost>
			{
			    new BlogPost {Text = "Text 1"},
			    new BlogPost {Text = "Text 2"},
			    new BlogPost {Text = "Text 1"}
			};
			return blogPosts.Distinct(new CustomComparer<BlogPost>()).ToList();
		}
	}
	//This comparer is required only one.
	public class CustomComparer<T> : IEqualityComparer<T> where T : class
	{
		public bool Equals(T x, T y)
		{
			if (y == null && x == null)
			{
				return true;
			}
			if (y == null || x == null)
			{
				return false;
			}
			if (x is Author && y is Author)
			{
				return ((Author)(object)x).Name == ((Author)(object)y).Name;
			}
			if (x is BlogPost && y is BlogPost)
			{
				return ((BlogPost)(object)x).Text == ((BlogPost)(object)y).Text;
			}
			//for next class add comparing logic here
			return false;
		}
		public int GetHashCode(T obj)
		{
			return 0; // actual generating hash code should be here
		}
	}
	public class Author
	{
		public string Name { get; set; }
	}
	public class BlogPost
	{
		public string Text { get; set; }
	}
