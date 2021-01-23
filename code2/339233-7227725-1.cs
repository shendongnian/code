    public class Content
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual IDictionary<ContentField, ContentFieldInfo> Fields { get; set; }
    }
    public class ContentField
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class ContentFieldInfo
    {
        public virtual Content Content { get; set; }
        public virtual ContentField Field { get; set; }
        public virtual string Values { get; set; }
        public virtual string AdditionalInfo { get; set; }
    }
    class ContentMap : ClassMap<Content>
    {
        public ContentMap()
        {
            Id(...);
            Map(c => c.Title);
            HasMany(c => c.Fields)
                .Table("ContentFieldItem")
                .KeyColumn("contentid")
                .AsMap(fieldinfo => fieldinfo.Field)
                .Component(comp => 
                {
                    comp.ParentReference(fi => fi.Content);
                    comp.References(fi => fi.ContentField);
                    comp.Map(fi => fi.Value);
                    ...
                });
        }
    }
    class ContentFieldMap : ClassMap<ContentField>
    {
        public ContentFieldMap()
        {
            Id(...);
            Map(c => c.Name);
        }
    }
