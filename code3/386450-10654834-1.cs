		void WriteFunctionImport(EdmFunction edmFunction, bool includeMergeOption)
		{
			var parameters = FunctionImportParameter.Create(edmFunction.Parameters, Code, EFTools);
			var paramList = String.Join(", ", parameters.Select(p => p.FunctionParameterType + " " + p.FunctionParameterName).ToArray());
			var returnType = edmFunction.ReturnParameter == null ? null : EFTools.GetElementType(edmFunction.ReturnParameter.TypeUsage);
			var processedReturn = returnType == null ? "int" : "ObjectResult<" + MultiSchemaEscape(returnType) + ">";
			if (includeMergeOption)
			{
				paramList = Code.StringAfter(paramList, ", ") + "MergeOption mergeOption";
			}
		#>
			<#=AccessibilityAndVirtual(Accessibility.ForMethod(edmFunction))#> <#=processedReturn#> <#=Code.Escape(edmFunction)#>(<#=paramList#>)
			{
		<#+
				if(returnType != null && (returnType.EdmType.BuiltInTypeKind == BuiltInTypeKind.EntityType ||
										  returnType.EdmType.BuiltInTypeKind == BuiltInTypeKind.ComplexType))
				{
		#>
				((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(<#=MultiSchemaEscape(returnType)#>).Assembly);
		<#+
				}
				foreach (var parameter in parameters.Where(p => p.NeedsLocalVariable))
				{
					var isNotNull = parameter.IsNullableOfT ? parameter.FunctionParameterName + ".HasValue" : parameter.FunctionParameterName + " != null";
					var notNullInit = "new SqlParameter(\"" + parameter.EsqlParameterName + "\", " + parameter.FunctionParameterName + ")";
					var nullInit = "new SqlParameter(\"" + parameter.EsqlParameterName + "\", typeof(" + parameter.RawClrTypeName + "))";
		#>
				var <#=parameter.LocalVariableName#> = <#=isNotNull#> ?
					<#=notNullInit#> :
					<#=nullInit#>;
		<#+
				}
				var genericArg = returnType == null ? "" : "<" + MultiSchemaEscape(returnType) + ">";
				var callParams = Code.StringBefore(", ", String.Join(", ", parameters.Select(p => p.ExecuteParameterName).ToArray()));
				var spParams = Code.StringBefore("@", String.Join(", @", parameters.Select(p => p.EsqlParameterName).ToArray()));
				if (includeMergeOption)
				{
					callParams = ", mergeOption" + callParams;
				}
		#>
				return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<#=genericArg#>("<#=edmFunction.Name#> <#=spParams#>"
							<#=callParams#>);
			}
		<#+
			if(!includeMergeOption && returnType != null && returnType.EdmType.BuiltInTypeKind == BuiltInTypeKind.EntityType)
			{
				WriteFunctionImport(edmFunction, true);
			}
		}
