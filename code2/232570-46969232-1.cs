    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    <#
    if (container.FunctionImports.Any())
    {
    #>
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    <#
    }
    #>
    
    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
        {
            public <#=code.Escape(container)#>()
                : base("name=<#=container.Name#>")
            {
        	base.Configuration.ProxyCreationEnabled = false;
        <#
        if (!loader.IsLazyLoadingEnabled(container))
        {
        #>
                this.Configuration.LazyLoadingEnabled = false;
        <#
        }
