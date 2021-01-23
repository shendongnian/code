    <#@ template language="C#v3.5" debug="True" #>
    <#@ output extension=".generated.cs" #>
    <#
        var modelNames = new string[] {
            "ClassName1",
            "ClassName2",
            "ClassName3",
        };
    
    	var namespaceName = "MyNamespace";
    #>
    using System;
    using System.Collections.Generic;
    
    namespace <#= namespaceName #>
    {
    <#
        for (int i = 0; i < modelNames.Length; ++i)
        {
            string modelName = modelNames[i];
            string eqcmpClassName = modelName + "ByIDEqualityComparer";
    #>
        #region <#= eqcmpClassName #>
    
        /// <summary>
        /// Use this EqualityComparer class to determine uniqueness among <#= modelName #> instances
        /// by using only checking the ID property.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        public sealed partial class <#= eqcmpClassName #> : IEqualityComparer<<#= modelName #>>
        {
            public bool Equals(<#= modelName #> x, <#= modelName #> y)
            {
                if ((x == null) && (y == null)) return true;
                if ((x == null) || (y == null)) return false;
    
                return x.ID.Equals(y.ID);
            }
    
            public int GetHashCode(<#= modelName #> obj)
            {
                if (obj == null) return 0;
    
                return obj.ID.GetHashCode();
            }
        }
    
        #endregion
    <#
            if (i < modelNames.Length - 1) WriteLine(String.Empty);
        } // for (int i = 0; i < modelNames.Length; ++i)
    #>
    }
