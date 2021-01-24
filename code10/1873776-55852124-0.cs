    public class ModifyParametersFilter : IParameterFilter
    {
        public void Apply(IParameter parameter, ParameterFilterContext context)
        {
            var type = context.ParameterInfo?.ParameterType;
            if (type == null)
                return;
            if (type.IsEnum)
            {
                var names = Enum.GetNames(type);
                var values = Enum.GetValues(type);
                var desc = "";
    
                foreach (var value in values)
                {
                    var intValue = Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()));
                    desc += $"{intValue}={value},";
                }
                desc = desc.TrimEnd(',');
                if (!parameter.Extensions.ContainsKey("x-enumNames"))
                    parameter.Extensions.Add("x-enumNames", names);
            }
        }
    }
