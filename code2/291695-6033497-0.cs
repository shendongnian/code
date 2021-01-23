    public abstract class Content
    {
        private Content() { }
        public abstract T Match<T>(Func<Blog, T> convertBlog, Func<BlogPost, T> convertPost);
        public class Blog : Content
        {
            public Blog(string title)
            {
                Title = title;
            }
            public string Title { get; private set; }
            public override T Match<T>(Func<Blog, T> convertBlog, Func<BlogPost, T> convertPost)
            {
                return convertBlog(this);
            }
        }
        public class BlogPost : Content
        {
            public BlogPost(string title, Blog blog)
            {
                Title = title;
                Blog = blog;
            }
            public string Title { get; private set; }
            public Blog Blog { get; private set; }
            public override T Match<T>(Func<Blog, T> convertBlog, Func<BlogPost, T> convertPost)
            {
                return convertPost(this);
            }
        }
    }
    public static class Example
    {
        public static string GetTitle(Content content)
        {
            return content.Match(blog => blog.Title, post => post.Blog.Title + ": " + post.Title);
        }
    }
