    public class OuterWrapper {
      public NS NS { get; set; }
      public Source Source { get; set; }
      public ContentItemWrapper[] Item { get; set; } 
    }
    public class ContentItemWrapper {
      public int Id { get; set; }
      public string Url { get; set; }
      public ContentItem[] ContentItem { get; set; }
    }
    public class ContentItem {
      public NS NS { get; set; }
      public SourceUrl { get; set; }
      // I'm gonna skip a bunch of fields, you get the idea
      public Topics Topic { get; set; }
    }
    public class Topics {
      public string Scheme { get; set; }
      public Topic[] Topic { get; set; }
    }
    public class Topic {
      public string TopicId { get; set; }
      public string TopicName { get; set; }
    }
