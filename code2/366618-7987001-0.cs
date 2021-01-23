      <#@ template   language    = "C#"                           #>
      <#@ assembly   name        = "Microsoft.CSharp"             #>
      <#@ assembly   name        = "System.Core"                  #>
      <#@ assembly   name        = "System.Data"                  #>
      <#@ import     namespace   = "System.Collections.Generic"   #>
      <#@ import     namespace   = "System.Dynamic"               #>
      <#@ import     namespace   = "System.Linq"                  #>
      <#@ import     namespace   = "System.Data.SqlClient"        #>
      <#
         var namespaceName    = "Poco2";
         // Update the connection string to something appropriate
         var connectionString = @"Data Source=localhost\SQLExpress;Initial Catalog=MyTest;Integrated Security=True";
      #>
      <#
         using (var db = new SqlConnection (connectionString))
         using (var cmd = db.CreateCommand ())
         {
            db.Open();
            var tables              = ReadRows (cmd, "SELECT * FROM sys.tables").ToArray ();
            var columns             = ReadRows (cmd, "SELECT * FROM sys.columns").ToLookup (k => k.object_id);
            var indexes             = ReadRows (cmd, "SELECT * FROM sys.indexes").ToLookup (k => k.object_id);
            var indexColumns        = ReadRows (cmd, "SELECT * FROM sys.index_columns").ToLookup (k => k.object_id);
            var foreignKeys         = ReadRows (cmd, "SELECT * FROM sys.foreign_keys").ToArray ();
            var foreignKeyColumns   = ReadRows (cmd, "SELECT * FROM sys.foreign_key_columns").ToArray ();
      #>
      namespace <#=namespaceName#>
      {
         using System;
         using System.Data.Linq.Mapping;
      <#
            foreach (var table in tables)
            {         
      #>
         [Table]
         partial class <#=table.name#>
         {
      <#
               IEnumerable<dynamic> tc = columns[table.object_id];
               var tableColumns = tc.OrderBy (r => r.column_id).ToArray ();          
               IEnumerable<dynamic> ti = indexes[table.object_id];
               var tableIndexes = ti.ToArray ();          
               var primaryKeyIndex = tableIndexes.FirstOrDefault (i => i.is_primary_key);
               var primaryKeyColumns = new Dictionary<dynamic, dynamic> ();
               if (primaryKeyIndex != null)
               {
                  IEnumerable<dynamic> pc = indexColumns[table.object_id];
                  primaryKeyColumns = pc
                     .Where (c => c.index_id == primaryKeyIndex.index_id)
                     .ToDictionary (c => c.column_id, c => c.key_ordinal)
                     ;
               }
               foreach (var tableColumn in tableColumns)
               {
                  var type = MapToType (tableColumn.user_type_id, tableColumn.max_length, tableColumn.is_nullable);
      #>
            [Column (IsPrimaryKey = <#=primaryKeyColumns.ContainsKey (tableColumn.column_id) ? "true" : "false"#>)]
            public <#=type#> <#=tableColumn.name#> {get;set;}
      <#
               }
      #>
         
         }
      <#
            }
      #>
      }
      <#
         }
      #>
      <#+
         struct DataType
         {     
            public readonly int     SizeOf;
            public readonly string  SingularType;
            public readonly string  PluralType;
            public DataType (
               int sizeOf,
               string singularType,
               string pluralType = null
               )
            {
               SizeOf         = sizeOf;
               SingularType   = singularType;
               PluralType     = pluralType ?? (singularType + "[]");
            }
         }
         static Dictionary<int, DataType> dataTypes = new Dictionary<int, DataType>
            {
               {61   , new DataType (8,  "DateTime"            )},
               {127  , new DataType (8,  "long"                )},
               {165  , new DataType (1,  "byte"                )},
               {231  , new DataType (2,  "char"    ,  "string" )},
            };
         static string MapToType (int typeId, int maxLength, bool isNullable)
         {
            DataType dataType;
            if (dataTypes.TryGetValue (typeId, out dataType))
            {
               var length = maxLength > 0 ? (maxLength / dataType.SizeOf) : int.MaxValue;
               if (length > 1)
               {
                  return dataType.PluralType;
               }
               else
               {
                  return dataType.SingularType + (isNullable ? "?" : "");
               }
            }
            else
            {
               return "UnknownType_"+ typeId;
            }
         }
         static IEnumerable<dynamic> ReadRows (SqlCommand command, string sql)
         {
            command.CommandText = sql ?? "";
            using (var reader = command.ExecuteReader())
            {
               while (reader.Read())
               {
                  var dyn = new ExpandoObject ();
                  IDictionary<string, object> dic = dyn;
                  for (var iter = 0; iter < reader.FieldCount; ++iter)
                  {
                        dic[reader.GetName(iter) ?? ""] = reader.GetValue(iter);
                  }
                  yield return dyn;
               }
            }
         }
   
      #>
