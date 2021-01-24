c#
// NuGet reference: ExcelDataReader v3.6.0 built from https://github.com/ExcelDataReader/ExcelDataReader/ExcelDataReader
// NuGet reference: ExcelDataReader.DataSet v3.6.0 built from https://github.com/ExcelDataReader/ExcelDataReader/ExcelDataReader.DataSet
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Linq;
namespace Convert_IExcelDataReader_values_to_string
{
    class MainClass
    {
        public static DataSet ReadExcelDataToDataSet(Stream fileStream)
        {
            DataSet excelDataSet;
            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fileStream))
            {
                var dataSetConfiguration = new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = false
                };
                // This reads each Sheet into a DataTable and each column is of type System.Object
                excelDataSet = reader.AsDataSet(dataSetConfiguration);
            }
            var stringDataSet = ConvertToDataSetOfStrings(excelDataSet);
            return stringDataSet;
        }
        private static DataSet ConvertToDataSetOfStrings(DataSet sourceDataSet)
        {
            var result = new DataSet();
            result.Tables.AddRange(
                sourceDataSet.Tables.Cast<DataTable>().Select(srcDataTable =>
                {
                    var destDataTable = new DataTable(srcDataTable.TableName, srcDataTable.Namespace);
                    // Copy each source column as System.String...
                    destDataTable.Columns.AddRange(
                        srcDataTable.Columns.Cast<DataColumn>()
                            .Select(col => new DataColumn(col.ColumnName, typeof(String)))
                            .ToArray()
                            );
                    // Implicitly convert all source cells to System.String using DataTable.ImportRow()
                    srcDataTable.Rows.OfType<DataRow>()
                    .ToList()
                    .ForEach(row => destDataTable.ImportRow(row));
                    return destDataTable;
                })
                .ToArray()
                );
            return result;
        }
        public static void Main(string[] args)
        {
            using (var stream = File.Open("TestOpenXml.xlsx", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var dataSet = ReadExcelDataToDataSet(stream);
            }
        }
    }
}
Hope this helps!
