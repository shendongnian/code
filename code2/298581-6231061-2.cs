    <#@ template language="C#" debug="False" hostspecific="True"  #>
    <#@ output extension=".cs" #>
    <#@ include file="DB2DataProvider.ttinclude" #>
    <#
        var sps = GetSPs(); 
        if(sps.Count>0){ 
    #>  
    using System;
    using System.Data;
    using System.ComponentModel;
    using SubSonic;
    using SubSonic.Schema;
    using SubSonic.DataProviders;
    
    namespace <#=Namespace#>{
    	public partial class <#=DatabaseName#>DB{
    
    		public T ConvertValue<T>(object paramVal)
            {
                if (paramVal == null || Convert.IsDBNull(paramVal))  // if the value is null, return the default for the desired type.
                    return default(T);
    			if (typeof(T) == paramVal.GetType())  // if types are already equal, no conversion needed. just cast.
    				return (T)paramVal;
    			else // types don't match. try to convert.
    			{
    				var conversionType = typeof(T);
    				if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
    				{
    					NullableConverter nullableConverter = new NullableConverter(conversionType);
    					conversionType = nullableConverter.UnderlyingType;
    				}
    				return (T)Convert.ChangeType(paramVal, conversionType);
    			}
            }
    
    <#  foreach(var sp in sps){#>
            public void <#=sp.CleanName#>(<#=sp.ArgList#>){
                StoredProcedure sp=new StoredProcedure("<#=sp.Name#>",this.Provider);
    <#      foreach(var par in sp.Parameters) {
              if(par.In && !par.Out) {#>
                sp.Command.AddParameter("<#=par.Name#>",<#=par.CleanName#>,DbType.<#=par.DbType#>);
    <#        } else if(!par.In && par.Out) {#>
                sp.Command.AddOutputParameter("<#=par.Name#>",DbType.<#=par.DbType#>);
    <#        } else {#>
                sp.Command.AddParameter("<#=par.Name#>",<#=par.CleanName#>,DbType.<#=par.DbType#>,ParameterDirection.InputOutput);
    <#      }}#>
                sp.Execute();
    <#      bool hasOut = false;
            foreach(var par in sp.Parameters) {
              if(par.Out)
                hasOut = true;
            }
            if(hasOut) {
    #>
                var prms = sp.Command.Parameters;
    <#      }
            foreach(var par in sp.Parameters) {
              if(par.Out) {#>
                <#=par.Name#> = ConvertValue<<#=par.SysType#>>(prms.GetParameter("<#=par.Name#>").ParameterValue);
    <#      }}#>
            }
    <#  }#>
    	
    	}
    	
    }
    <#  }#>
