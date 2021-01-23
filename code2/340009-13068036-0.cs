    object[,] valueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
                            //Get the column names
                            for (int k = 0; k < valueArray.GetLength(1); )
                            {
                                //add columns to the data table.
                                dt.Columns.Add((string)valueArray[1,++k]);
                            }
                            //Load data into data table
                            object[] singleDValue = new object[valueArray.GetLength(1)];
                            //value array first row contains column names. so loop starts from 1 instead of 0
                            for (int i = 1; i < valueArray.GetLength(0); i++)
                            {
                                Console.WriteLine(valueArray.GetLength(0) + ":" + valueArray.GetLength(1));
                                for (int k = 0; k < valueArray.GetLength(1); )
                                {
                                    singleDValue[k] = valueArray[i+1, ++k];
                                }
                                dt.LoadDataRow(singleDValue, System.Data.LoadOption.PreserveChanges);
                            }
