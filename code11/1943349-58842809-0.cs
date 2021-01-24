`
public class Topic
{
    [Key]
    public int TopicId {get; set;}
    public int PostCount {get; set;}
    public string Title {get; set;}
    public string OriginalPoster {get; set;}
    public IList<Post> Posts{get; set;}
}
public class Post
{
    [Key]
    public int PostId {get; set;}
    ForeignKey("Topic")]
    public int TopicId{get; set;}
    public DateTime TimeStamp {get; set;}
    public string Poster {get; set;}
    public string Body {get; set;}
}
`
Now, EF is going to know how these two classes relate to each other, and how.
I ***think*** that this should be enough to get your code to work. But if you run into any other problems, either post a comment below or start a new question (and post a comment below with a link to the new question.
Hope this helps!
