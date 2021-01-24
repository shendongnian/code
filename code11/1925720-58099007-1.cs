    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Security.Permissions;
    
    public class C
    {
        [Dynamic]
        private object <SomeProp>k__BackingField;
    
        [Dynamic]
        public object SomeProp
        {
            [return: Dynamic]
            get
            {
                return <SomeProp>k__BackingField;
            }
            [param: Dynamic]
            set
            {
                <SomeProp>k__BackingField = value;
            }
        }
    
        public void M()
        {
            SomeProp = 3;
        }
    }
