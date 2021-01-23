    public class ColumnUppercaseConvention : IConfigurationConvention<MemberInfo, PrimitivePropertyConfiguration> {
        public void Apply(MemberInfo memberInfo, Func<PrimitivePropertyConfiguration> configuration) {
            configuration().ColumnName = memberInfo.Name.ToUpper();
        }
    }
