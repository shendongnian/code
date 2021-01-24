    public class SpecificCommandType : CommandType<SpecificCommand> {
       protected override void Configure(IInputObjectTypeDescriptor<SpecificCommand> desc) {
          base.Configure(desc);
          desc.Field(t => t.Website).Type<NonNullType<UrlType>>();
       }
    }
