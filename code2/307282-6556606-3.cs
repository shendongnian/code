    public class ChannelContextFieldNameResolver : IAssociateFieldNameResolver
    {
        public string ResolveFieldName(object i_Object)
        {
            return (i_Object as ChannelContext).NominalId;
        }
    }
