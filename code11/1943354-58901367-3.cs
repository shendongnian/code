    public class Topic
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }
        public int PostCount { get; set; }
        public string Title { get; set; }
        public string OriginalPoster { get; set; }
    }
    public class Post
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public DateTime TimeStamp { get; set; }
        public string Poster { get; set; }
        public string Body { get; set; }
    }
3. I copied your code and put it on GitHub. You can click this [link](https://github.com/jianba/ASP.NET-Core-MVC-with-EF-Core---tutorial-series/blob/master/ContosoUniversity/Controllers/TopicController.cs) to see how I can implement an insert operation.This is the code for the insert part
        [HttpPost]
        public async Task<IActionResult> CreateTopic(TopicViewModel model)
        {
            var topic = new Topic
            {
                Title = model.Title,
                OriginalPoster = model.OriginalPoster,
                PostCount = model.PostCount
            };
            await _context.AddAsync(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            var post = new Post
            {
                TopicId = model.TopicId,
                TimeStamp = model.TimeStamp,
                Poster = model.Poster,
                Body = model.Body
            };
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
4. Through the above description and code should be able to solve your current problem.
###Other Tips###
1. There are some deviations in your understanding of the Model in .Net core. Model can be divided into two types: mapping database entities and providing services for front-end page work. Related [documents](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application).
2. The documentation of. Net core is not very comprehensive. Many small knowledge can be found [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/index).
