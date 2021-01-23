    public static class DataTableExtension
    {
        /// <summary>
        ///  Convert a database data table to a runtime dynamic definied type collection (dynamic class' name as table name).
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static List<dynamic> ToDynamicList(DataTable dt, string className)
        {
            return ToDynamicList(ToDictionary(dt), getNewObject(dt.Columns, className));
        }
       
        private static List<Dictionary<string, object>> ToDictionary(DataTable dt)
        {
            var columns = dt.Columns.Cast<DataColumn>();
            var Temp = dt.AsEnumerable().Select(dataRow => columns.Select(column =>
                                 new { Column = column.ColumnName, Value = dataRow[column] })
                             .ToDictionary(data => data.Column, data => data.Value)).ToList();
            return Temp.ToList();
        }
        private static List<dynamic> ToDynamicList(List<Dictionary<string, object>> list, Type TypeObj)
        {
            dynamic temp = new List<dynamic>();
            foreach (Dictionary<string, object> step in list)
            {
                object Obj = Activator.CreateInstance(TypeObj);
              
                PropertyInfo[] properties = Obj.GetType().GetProperties();
                
                Dictionary<string, object> DictList = (Dictionary<string, object>)step;
                
                foreach (KeyValuePair<string, object> keyValuePair in DictList)
                {
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.Name == keyValuePair.Key)
                        {
                            if (keyValuePair.Value != null && keyValuePair.Value.GetType() != typeof(System.DBNull))
                            {
                                if (keyValuePair.Value.GetType() == typeof(System.Guid))
                                {
                                    property.SetValue(Obj, keyValuePair.Value, null);
                                }
                                else
                                {
                                    property.SetValue(Obj, keyValuePair.Value, null);
                                }
                            }
                            break;
                        }
                    }
                }
                temp.Add(Obj);
            }
            return temp;
        }
    
        private static Type getNewObject(DataColumnCollection columns, string className)
        {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "HQODataCubeAssembly";
            System.Reflection.Emit.AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder module = assemblyBuilder.DefineDynamicModule("HQODataCubeDynamicModule");
            TypeBuilder typeBuilder = module.DefineType(className, TypeAttributes.Public);
            
            foreach (DataColumn column in columns)
            {
                string propertyName = column.ColumnName;
                FieldBuilder field = typeBuilder.DefineField(propertyName, column.DataType, FieldAttributes.Public);
                PropertyBuilder property = typeBuilder.DefineProperty(propertyName, System.Reflection.PropertyAttributes.None, column.DataType, new Type[] { column.DataType });
                MethodAttributes GetSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
                MethodBuilder currGetPropMthdBldr = typeBuilder.DefineMethod("get_value", GetSetAttr, column.DataType, new Type[] { column.DataType }); // Type.EmptyTypes);
                ILGenerator currGetIL = currGetPropMthdBldr.GetILGenerator();
                currGetIL.Emit(OpCodes.Ldarg_0);
                currGetIL.Emit(OpCodes.Ldfld, field);
                currGetIL.Emit(OpCodes.Ret);
                MethodBuilder currSetPropMthdBldr = typeBuilder.DefineMethod("set_value", GetSetAttr, null, new Type[] { column.DataType });
                ILGenerator currSetIL = currSetPropMthdBldr.GetILGenerator();
                currSetIL.Emit(OpCodes.Ldarg_0);
                currSetIL.Emit(OpCodes.Ldarg_1);
                currSetIL.Emit(OpCodes.Stfld, field);
                currSetIL.Emit(OpCodes.Ret);
                property.SetGetMethod(currGetPropMthdBldr);
                property.SetSetMethod(currSetPropMthdBldr);
            }
            Type obj = typeBuilder.CreateType();
            return obj;
        }      
    }
