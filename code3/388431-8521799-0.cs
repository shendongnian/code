    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool IsId(Member member)
        {
            return member.Name == member.DeclaringType.Name + "Id";
        }
    }
