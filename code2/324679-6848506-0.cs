    public class TaggingModel
    {
       public string TagList {get; set;}
       public PostClass Post {get; set;}
    }
    public TaggingModel(string tagList, Post post)
    {
        this.TagList = tagList;
        this.YourPost = post;
    }
