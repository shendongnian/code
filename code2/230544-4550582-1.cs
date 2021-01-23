    <#
    	GenerationEnvironment.Clear();
    	string templateDirectory = Path.GetDirectoryName(Host.TemplateFile);	
    	string outputPath = Path.Combine(templateDirectory + @"..\..\Models\Interfaces\Repositories\IEntitiesContext.cs");
    #>
    
    using System;
    using System.Data.Objects;
    using Models.DataModels;
    
    namespace Interfaces.Repositories
    {
    	#pragma warning disable 1591
        public interface IEntitiesContext : IDisposable
        {
    	<#
            region.Begin("ObjectSet Properties", 2);
    
            foreach (EntitySet entitySet in container.BaseEntitySets.OfType<EntitySet>())
            {
    #>
    		IObjectSet<<#=code.Escape(entitySet.ElementType)#>> <#=code.Escape(entitySet)#> { get; }
    <#
            }
            region.End();
    
    		region.Begin("Function Imports", 2);
    		
            foreach (EdmFunction edmFunction in container.FunctionImports)
            {
                var parameters = FunctionImportParameter.Create(edmFunction.Parameters, code, ef);
                string paramList = String.Join(", ", parameters.Select(p => p.FunctionParameterType + " " + p.FunctionParameterName).ToArray());
                if (edmFunction.ReturnParameter == null)
                {
                    continue;
                }
                string returnTypeElement = code.Escape(ef.GetElementType(edmFunction.ReturnParameter.TypeUsage));
    
    #>
        ObjectResult<<#=returnTypeElement#>> <#=code.Escape(edmFunction)#>(<#=paramList#>);
    <#
            }
    
            region.End();
    #>
    
    		int SaveChanges();
            ObjectContextOptions ContextOptions { get; }
            System.Data.Common.DbConnection Connection { get; }
    		ObjectSet<T> CreateObjectSet<T>() where T : class;
    	}
    	#pragma warning restore 1591
    }
    <#
    		System.IO.File.WriteAllText(outputPath, GenerationEnvironment.ToString());
    		GenerationEnvironment.Clear();
    #>
