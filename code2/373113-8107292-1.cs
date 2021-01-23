    <#@ template    language    = "C#"                                      #> 
    <#@ assembly    name        = "Microsoft.SqlServer.Management.Sdk.Sfc"  #> 
    <#@ assembly    name        = "Microsoft.SqlServer.ConnectionInfo"      #> 
    <#@ assembly    name        = "Microsoft.SqlServer.Smo"                 #> 
    <#@ assembly    name        = "System.Core"                             #> 
    <#@ assembly    name        = "System.XML"                              #> 
    <#@ import      namespace   = "Microsoft.SqlServer.Management.Smo"      #> 
    <#@ import      namespace   = "System.Collections.Generic"              #> 
    <#@ import      namespace   = "System.Linq"                             #> 
    <#@ import      namespace   = "System.Text"                             #> 
    // ReSharper disable InconsistentNaming
    // ReSharper disable PartialTypeWithSinglePart
 
    <#
        // Update SQL Server and namespace
        var nameSpace   = "MyNameSpace";
        var server      = new Server (@"localhost\SQLExpress");
        var database    = new Database (server,"MyDB");
        var maxTables   = int.MaxValue; 
        database.Refresh (); 
    #>
    namespace <#=nameSpace#>
    { 
        using System;
        using System.Collections.Generic;
        using System.Data.SqlClient;
        static partial class Extensions
        {
            static int Lookup (Dictionary<string, int> dic, string key)
            {
                int value;
                return dic.TryGetValue (key, out value) ? value : -1;
            }
            static byte[] GetByteArray (this SqlDataReader reader, int index)
            {
                var byteLength = reader.GetBytes (index, 0, null, 0, 0);
                var bytes = new byte[byteLength];
                reader.GetBytes (index, 0, bytes, 0, bytes.Length);
                return bytes;
            }
    <#
        foreach (var table in database.Tables.OfType<Table> ().Take (maxTables))
        {
    #>
            // --------------------------------------------------------------------
            // Deletes <#=table.Name#>
            // --------------------------------------------------------------------
            public static int Delete_<#=table.Name#> (
                this SqlCommand command
    <#
                    foreach (var column in table.Columns.OfType<Column> ().Where (c => c.InPrimaryKey))
                    {
    #>
                ,   <#=GetType (column)#> <#=column.Name#>
    <#
                    }
    #>
                )
            {
                if (command != null)
                {
                    command.CommandText = "DELETE FROM <#=table.Schema#>.<#=table.Name#> <#=GetWhereClause (table)#>";
                    command.Parameters.Clear ();
    <#
                    foreach (var column in table.Columns.OfType<Column> ().Where (c => c.InPrimaryKey))
                    {
    #>
                    command.Parameters.AddWithValue (@"<#=column.Name#>", <#=column.Name#>);
    <#
                    }
    #>
                    return command.ExecuteNonQuery ();
                }
                else
                {
                    return 0;
                }
            }
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            // Gets <#=table.Name#>
            // --------------------------------------------------------------------
            public static IEnumerable<<#=table.Name#>> Get_<#=table.Name#> (
                this SqlCommand command
    <#
                    foreach (var column in table.Columns.OfType<Column> ().Where (c => c.InPrimaryKey))
                    {
    #>
                ,   <#=GetType (column)#> <#=column.Name#>
    <#
                    }
    #>
                )
            {
                if (command != null)
                {
                    command.CommandText = "SELECT * FROM <#=table.Schema#>.<#=table.Name#> <#=GetWhereClause (table)#>";
                    command.Parameters.Clear ();
    <#
                    foreach (var column in table.Columns.OfType<Column> ().Where (c => c.InPrimaryKey))
                    {
    #>
                    command.Parameters.AddWithValue (@"<#=column.Name#>", <#=column.Name#>);
    <#
                    }
    #>
                    using (var reader = command.ExecuteReader ())
                    {
                        foreach (var row in reader.To_<#=table.Name#> ())
                        {
                            yield return row;
                        }
                    }
                }
            }
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            // Deserializes a <#=table.Name#>
            // --------------------------------------------------------------------
            public static IEnumerable<<#=table.Name#>> To_<#=table.Name#> (this SqlDataReader reader)
            {
                if (reader != null)
                {
                    var fieldCount = reader.FieldCount;
                    var dictionary = new Dictionary<string, int> ();
                    for (var iter = 0; iter < fieldCount; ++iter)
                    {
                        dictionary[reader.GetName (iter)] = iter;
                    }
                    while (reader.Read ())
                    {
                        var instance = new <#=table.Name#> ();
    <#
                    foreach (var column in table.Columns.OfType<Column> ())
                    {
    #>
                        {
                            var index = Lookup (dictionary, "<#=column.Name#>");
                            if (index > -1)
                            {
                                instance.<#=column.Name #> = reader.<#=GetGetter (column)#> (index);
                            }
                        }
    <#                
                    }
    #>
                        yield return instance;
                    }
                }
            }
            // --------------------------------------------------------------------
    <#
        }
    #>
        }
    <#
        foreach (var table in database.Tables.OfType<Table> ().Take (maxTables))
        {
    #>
        // ------------------------------------------------------------------------
        // Table: <#=table.Name#>
        // ------------------------------------------------------------------------
        partial class <#=table.Name#>
        {
    <#
            foreach (var column in table.Columns.OfType<Column> ())
            {
    #>
            // <#=column.DataType.Name#> (<#=column.Nullable#>, <#=column.DataType.MaximumLength#>, <#=column.DataType.SqlDataType#>)
            public <#=GetType (column)#> <#=column.Name#> {get;set;}
    <#
            }
    #>
        }
        // ------------------------------------------------------------------------
    <#
        }
    #>
    } 
    <#+
        sealed class DataTypeDescriptor
        {
            public readonly bool IsValueType;
            public readonly string Type;
            public readonly string Getter;
            public DataTypeDescriptor (
                bool isValueType, 
                string type,
                string getter = null
                )
            {
                IsValueType     = isValueType;
                Type            = type;
                Getter          = getter ?? ("Get" + type);
            }
        }
        readonly static Dictionary<SqlDataType, DataTypeDescriptor> s_typeDescriptors =
            new Dictionary<SqlDataType, DataTypeDescriptor> ()
                {
                    // Unsupported:
                    // ------------
                    // None, 
                    // UserDefinedDataType, 
                    // UserDefinedDataType, 
                    // XML, 
                    // SysName, 
                    // UserDefinedTableType, 
                    // HierarchyId, 
                    // Geometry, 
                    // Geography
                    {SqlDataType.BigInt             , new DataTypeDescriptor (true  , "Int64"            )},
                    {SqlDataType.Binary             , new DataTypeDescriptor (true  , "Byte"            )},
                    {SqlDataType.Bit                , new DataTypeDescriptor (true  , "Boolean"            )},
                    {SqlDataType.Char               , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.DateTime           , new DataTypeDescriptor (true  , "DateTime"        )},
                    {SqlDataType.Decimal            , new DataTypeDescriptor (true  , "Decimal"         )},
                    {SqlDataType.Float              , new DataTypeDescriptor (true  , "Double"          )},
                    {SqlDataType.Image              , new DataTypeDescriptor (false , "byte[]"  , "GetByteArray"          )},
                    {SqlDataType.Int                , new DataTypeDescriptor (true  , "Int32"             )},
                    {SqlDataType.Money              , new DataTypeDescriptor (true  , "Decimal"         )},
                    {SqlDataType.NChar              , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.NText              , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.NVarChar           , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.NVarCharMax        , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.Real               , new DataTypeDescriptor (true  , "Double"          )},
                    {SqlDataType.SmallDateTime      , new DataTypeDescriptor (true  , "DateTime"        )},
                    {SqlDataType.SmallInt           , new DataTypeDescriptor (true  , "Int16"           )},
                    {SqlDataType.SmallMoney         , new DataTypeDescriptor (true  , "Decimal"         )},
                    {SqlDataType.Text               , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.Timestamp          , new DataTypeDescriptor (false , "byte[]"  , "GetByteArray"          )},
                    {SqlDataType.TinyInt            , new DataTypeDescriptor (true  , "Byte"            )},
                    {SqlDataType.UniqueIdentifier   , new DataTypeDescriptor (false , "byte[]"  , "GetByteArray"          )},
                    {SqlDataType.VarBinary          , new DataTypeDescriptor (false , "byte[]"  , "GetByteArray"        )},
                    {SqlDataType.VarBinaryMax       , new DataTypeDescriptor (false , "byte[]"  , "GetByteArray"        )},
                    {SqlDataType.VarChar            , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.VarCharMax         , new DataTypeDescriptor (false , "String"          )},
                    {SqlDataType.Variant            , new DataTypeDescriptor (false , "object"  , "GetValue")},
                    {SqlDataType.Numeric            , new DataTypeDescriptor (true  , "Decimal"         )},
                    {SqlDataType.Date               , new DataTypeDescriptor (true  , "DateTime"        )},
                    {SqlDataType.Time               , new DataTypeDescriptor (true  , "TimeSpan"        )},
                    {SqlDataType.DateTimeOffset     , new DataTypeDescriptor (true  , "DateTimeOffset"  )},
                    {SqlDataType.DateTime2          , new DataTypeDescriptor (true  , "DateTime"        )},
                };                                                                                  
                                                                                                
        static string GetGetter (Column column)
        {
            var dataType = column.DataType;
            DataTypeDescriptor descriptor;
            if (!s_typeDescriptors.TryGetValue (dataType.SqlDataType, out descriptor))
            {
                return
                        "Error__Unsupported_Type_" 
                    +   dataType.SqlDataType
                    ;
            }
            return descriptor.Getter;
        }
        static string GetType (Column column)
        {
            var dataType = column.DataType;
            DataTypeDescriptor descriptor;
            if (!s_typeDescriptors.TryGetValue (dataType.SqlDataType, out descriptor))
            {
                return 
                        "Error__Unsupported_Type_" 
                    +   dataType.SqlDataType
                    ;
            }
            if (column.Nullable && descriptor.IsValueType)
            {
                return descriptor.Type + "?";
            }
            return descriptor.Type;
        }
        static string GetWhereClause (Table table)
        {
            var sb = new StringBuilder ("WHERE ");
            var first = true;
            foreach (var column in table.Columns.OfType<Column> ().Where (c => c.InPrimaryKey))
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append (" AND ");
                }
            
                sb.AppendFormat ("{0} = @{0}", column.Name);
            }
            return sb.ToString ();
        }
    #>
