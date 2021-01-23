    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    
    namespace BusinessLayer
    {
        public static class ConvertDataTable
        {
            public static DataTable ToTable<T>(this IEnumerable<T> varlist, CreateRowDelegate<T> fn)
            {
    
                DataTable dtReturn = new DataTable();
                // Could add a check to verify that there is an element 0
    
                T TopRec = varlist.ElementAt(0);
    
                // Use reflection to get property names, to create table
    
                // column names
    
                PropertyInfo[] oProps =
                ((Type)TopRec.GetType()).GetProperties();
    
                foreach (PropertyInfo pi in oProps)
                {
    
                    Type colType = pi.PropertyType; if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
    
                        colType = colType.GetGenericArguments()[0];
    
                    }
    
                    dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                }
    
                foreach (T rec in varlist)
                {
    
                    DataRow dr = dtReturn.NewRow(); foreach (PropertyInfo pi in oProps)
                    {
                        dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                    }
                    dtReturn.Rows.Add(dr);
    
                }
    
                return (dtReturn);
            }
    
            public delegate object[] CreateRowDelegate<T>(T t);
        }
    }
