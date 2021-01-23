    using System;
    using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
    using System.Data.Entity.ModelConfiguration.Conventions.Configuration;
    using System.Reflection;
    
    public class MakeAllStringsNonUnicode :
        IConfigurationConvention<PropertyInfo, StringPropertyConfiguration>
    {
        public void Apply(PropertyInfo propertyInfo, 
                          Func<StringPropertyConfiguration> configuration)
        {
            configuration().IsUnicode = false;
        }
    }
