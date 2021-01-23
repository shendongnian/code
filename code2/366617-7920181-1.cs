    public partial class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
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
