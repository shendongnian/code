            var comments = new Comments();
            var threeComments = new List<Comment>
                                    {
                                        new Comment("t1", "d1", "n1", "i1"),
                                        new Comment("t2", "d2", "n2", "i3"),
                                        new Comment("t3", "d3", "n3", "i3")
                                    };
            comments.comments = threeComments.ToArray();
            commentsLooper.ItemsSource = new CommentsDataItems(comments);
    public class Comments
    {
        public Comment[] comments { get; set; }
    }
    public class CommentsDataItems : ObservableCollection<CommentDataItem>
    {
        public CommentsDataItems(Comments comments)
        {
            foreach (var com in comments.comments)
            {
                Add(new CommentDataItem(com.text, com.device, com.name, com.id));
            }
        }
    }
    public class CommentDataItem
    {
        public String text { get; set; }
        public String device { get; set; }
        public String name { get; set; }
        public String id { get; set; }
        public CommentDataItem(String text, String device, String name, String id)
        {
            this.text = text;
            this.device = device;
            this.name = name;
            this.id = id;
        }
    }
    public class Comment
    {
        public String text { get; set; }
        public String device { get; set; }
        public String name { get; set; }
        public String id { get; set; }
        public Comment(String text, String device, String name, String id)
        {
            this.text = text;
            this.device = device;
            this.name = name;
            this.id = id;
        }
    }
