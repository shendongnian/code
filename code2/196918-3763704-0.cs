if (ef.IsKey(primitiveProperty))
            {
                if (ef.ClrType(primitiveProperty.TypeUsage) == typeof(byte[]))
                {
#>
            if (!StructuralObject.BinaryEquals(&lt;#=code.FieldName(primitiveProperty)#>, value))
&lt;#+
                }
                else
                {
#>
            // Here it inject the if condition:
            if (&lt;#=code.FieldName(primitiveProperty)#> != value )
&lt;#+
                }
#>
            {
&lt;#+
        PushIndent(CodeRegion.GetIndent(1));
            }
#>
            &lt;#=ChangingMethodName(primitiveProperty)#>(value);
            ReportPropertyChanging("&lt;#=primitiveProperty.Name#>");
            &lt;#=code.FieldName(primitiveProperty)#> = StructuralObject.SetValidValue(value&lt;#=OptionalNullableParameterForSetValidValue(primitiveProperty, code)#>);
            ReportPropertyChanged("&lt;#=primitiveProperty.Name#>");
            &lt;#=ChangedMethodName(primitiveProperty)#>();
&lt;#+
        if (ef.IsKey(primitiveProperty))
            {
        PopIndent();
#>
            }
&lt;#+
            }
#>
        }
