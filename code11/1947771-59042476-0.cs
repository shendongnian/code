    public class ShouldDeserializeContractResolver : DefaultContractResolver
    {
        public static new readonly ShouldDeserializeContractResolver Instance = new ShouldDeserializeContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
    
            MethodInfo shouldDeserializeMethodInfo = member.DeclaringType.GetMethod("ShouldDeserialize" + member.Name);
    
            if (shouldDeserializeMethodInfo != null)
            {
                property.ShouldDeserialize = o => { return (bool)shouldDeserializeMethodInfo.Invoke(o, null); };
            }
    
            return property;
        }
    }
