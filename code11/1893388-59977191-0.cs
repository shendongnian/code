    public class ExcludeObsoletePropertiesResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var members =  base.GetSerializableMembers(objectType);
            members.RemoveAll(m => m.IsDefined(typeof(ObsoleteAttribute), true));
            return members;
        }
    }
