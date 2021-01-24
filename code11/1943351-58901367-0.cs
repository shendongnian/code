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
4. I copied your code and put it on GitHub. You can click this [link](https://github.com/jianba/ASP.NET-Core-MVC-with-EF-Core---tutorial-series/blob/master/ContosoUniversity/Controllers/TopicController.cs) to see how I can implement an insert operation.
5. There are some deviations in your understanding of the Model in .Net core. Mdoel can be divided into two types: mapping database entities and providing services for front-end page work.
