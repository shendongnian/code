    using System.Data.Linq.Mapping;
    using System.Reflection;
    using System;
    namespace L2STest
    {
        partial class MyDataContext
        {
            [Function(Name = "GetDate", IsComposable = true)]
            public DateTime GetSystemDate()
            {
                MethodInfo mi = MethodBase.GetCurrentMethod() as MethodInfo;
                return (DateTime)this.ExecuteMethodCall(this, mi, new object[] { }).ReturnValue;
            }
        }
    }
