        #region "Convert DataTable to List<dynamic>"
        public List<dynamic> ToDynamicList(DataTable dt)
        {
            List<string> cols = (dt.Columns.Cast<DataColumn>()).Select(column => column.ColumnName).ToList();
            return ToDynamicList(ToDictionary(dt), getNewObject(cols));
        }
        public List<Dictionary<string, object>> ToDictionary(DataTable dt)
        {
            var columns = dt.Columns.Cast<DataColumn>();
            var Temp = dt.AsEnumerable().Select(dataRow => columns.Select(column =>
                                 new { Column = column.ColumnName, Value = dataRow[column] })
                             .ToDictionary(data => data.Column, data => data.Value)).ToList();
            return Temp.ToList();
        }
        public List<dynamic> ToDynamicList(List<Dictionary<string, object>> list, Type TypeObj)
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
                            property.SetValue(Obj, keyValuePair.Value.ToString(), null);
                            break;
                        }
                    }
                }
                temp.Add(Obj);
            }
            return temp;
        }       
        private Type getNewObject(List<string> list)
        {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "tmpAssembly";
            AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder module = assemblyBuilder.DefineDynamicModule("tmpModule");
            TypeBuilder typeBuilder = module.DefineType("WebgridRowCellCollection", TypeAttributes.Public);
            foreach (string step in list)
            {
                string propertyName = step;
                FieldBuilder field = typeBuilder.DefineField(propertyName, typeof(string), FieldAttributes.Public);
                PropertyBuilder property = typeBuilder.DefineProperty(propertyName, System.Reflection.PropertyAttributes.None, typeof(string), new Type[] { typeof(string) });
                MethodAttributes GetSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
                MethodBuilder currGetPropMthdBldr = typeBuilder.DefineMethod("get_value", GetSetAttr, typeof(string), Type.EmptyTypes);
                ILGenerator currGetIL = currGetPropMthdBldr.GetILGenerator();
                currGetIL.Emit(OpCodes.Ldarg_0);
                currGetIL.Emit(OpCodes.Ldfld, field);
                currGetIL.Emit(OpCodes.Ret);
                MethodBuilder currSetPropMthdBldr = typeBuilder.DefineMethod("set_value", GetSetAttr, null, new Type[] { typeof(string) });
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
        #endregion
