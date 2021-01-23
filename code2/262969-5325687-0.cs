    enum dataType
        {
            System_Boolean = 0,
            System_Int32 = 1,
            System_Int64 = 2,
            System_Double = 3,
            System_DateTime = 4,
            System_String = 5
        }
    
        private dataType ParseString(string str)
        {
    
            bool boolValue;
            Int32 intValue;
            Int64 bigintValue;
            double doubleValue;
            DateTime dateValue;
    
            // Place checks higher if if-else statement to give higher priority to type.
    
            if (bool.TryParse(str, out boolValue))
                return dataType.System_Boolean;
            else if (Int32.TryParse(str, out intValue))
                return dataType.System_Int32;
            else if (Int64.TryParse(str, out bigintValue))
                return dataType.System_Int64;
            else if (double.TryParse(str, out doubleValue))
                return dataType.System_Double;
            else if (DateTime.TryParse(str, out dateValue))
                return dataType.System_DateTime;
            else return dataType.System_String;
    
        }
    
    
        /// <summary>
        /// Gets the datatype for the Datacolumn column
        /// </summary>
        /// <param name="column">Datacolumn to get datatype of</param>
        /// <param name="dt">DataTable to get datatype from</param>
        /// <param name="colSize">ref value to return size for string type</param>
        /// <returns></returns>
        public Type GetColumnType(DataColumn column, DataTable dt, ref int colSize)
        {
    
            Type T;
            DataView dv = new DataView(dt);
            //get smallest and largest values
            string colName = column.ColumnName;
    
            dv.RowFilter = "[" + colName + "] = MIN([" + colName + "])";
            DataTable dtRange = dv.ToTable();
            string strMinValue = dtRange.Rows[0][column.ColumnName].ToString();
            int minValueLevel = (int)ParseString(strMinValue);
    
            dv.RowFilter = "[" + colName + "] = MAX([" + colName + "])";
            dtRange = dv.ToTable();
            string strMaxValue = dtRange.Rows[0][column.ColumnName].ToString();
            int maxValueLevel = (int)ParseString(strMaxValue);
            colSize = strMaxValue.Length;
    
            //get max typelevel of first n to 50 rows
            int sampleSize = Math.Max(dt.Rows.Count, 50);
            int maxLevel = Math.Max(minValueLevel, maxValueLevel);
    
            for (int i = 0; i < sampleSize; i++)
            {
                maxLevel = Math.Max((int)ParseString(dt.Rows[i][column].ToString()), maxLevel);
            }
    
            string enumCheck = ((dataType)maxLevel).ToString();
            T = Type.GetType(enumCheck.Replace('_', '.'));
    
            //if typelevel = int32 check for bit only data & cast to bool
            if (maxLevel == 1 && Convert.ToInt32(strMinValue) == 0 && Convert.ToInt32(strMaxValue) == 1)
            {
                T = Type.GetType("System.Boolean");
            }
    
            if (maxLevel != 5) colSize = -1;
    
            
            return T;
        }
