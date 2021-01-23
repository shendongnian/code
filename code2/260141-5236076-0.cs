    public class YourPocoClass
    {
       public whateverContentIs Content { get; set; }
       public whateverContentTypeIs ContentType { get; set; }
    }
    var contents = from content in context.Contents
                   join contenttype in context.ContentTypes on content.ContentTypeID equals contenttype.ContentTypeID
                   select new YourPocoClass() {Content = content, ContentType = contenttype };
    Console.WriteLine(((YourPocoClass)dataGrid1.SelectedItem).Content);
