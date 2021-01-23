    class Base
    {
       bool IsCollection;
    }
    
    class StringItem : Base
    {
       string Contents;
       IsCollection = false;
       override ToString() { return this.Contents; }
    }
    
    class ListItem : Base
    {
       List<StringItem> Contents;
       IsCollection = true;
       override ToString() { return string.Join(",", this.Contents.ToArray() }
    }
