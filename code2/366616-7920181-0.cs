    public partial class Customer
    {
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    }
    	
    <#@ template language="C#" debug="False" hostspecific="True"  #>
    <#@ output extension=".cs" #>
    <#@ include file="SQLServer.ttinclude" #>
    <#
        var tables = LoadTables();
    #>
    using System;
    using System.ComponentModel;
    using System.Linq;
    
    namespace <#=Namespace#>
    {
        
        
    <#  foreach(Table tbl in tables){#>    
        
        /// <summary>
        /// A class which represents the <#=tbl.Name#> table in the <#=DatabaseName#> Database.
        /// This class is queryable through <#=DatabaseName#>DB.<#=tbl.ClassName#> 
        /// </summary>
    
    	public partial class <#=tbl.ClassName#>
    	{
    	    #region Properties
    	    
    <#      foreach(var col in tbl.Columns){
    			if (tbl.ClassName == col.CleanName)
    			{
    				col.CleanName += "X";
    			}
    #>
    		public <#=col.SysType#><#=CheckNullable(col)#> <#=col.CleanName#> { get; set; }
    <#      }#>
    
            #endregion
    
    	}
    	
    <#}#>
    }
