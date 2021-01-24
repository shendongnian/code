    public class QueryType: ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
             [...]
             descriptor.Field(t => t.GetMyEntity(default))
                .Argument("myArgument", a => a.Type<NonNullType<UrlType>>());
             [...]
        }
    }
