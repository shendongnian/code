    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("INSERT INTO Product (Name,Count,Brand,Type,Code) VALUES (\"Toys\",4,NULL,\"Child Toy\",\"T001\")");
                Console.WriteLine(GetCorrectedInsertStatement("INSERT INTO Product (Name,Count,Brand,Type,Code) VALUES (\"Toys\",4,NULL,\"Child Toy\",\"T001\")", "Brand", "Code"));
    
            }
    
            private static string GetCorrectedInsertStatement(string sqlInput, params string[] columnssToRemove)
            {
                string sqlOutput = string.Empty;
    
                if (columnssToRemove.Length == 0)
                {
                    return sqlInput;
                }
    
                int indexOpenBracket = sqlInput.IndexOf('(');
    
                // Copy prepare sqlOutput with INSERT INTO [Table] ({0}) VALUES ({1})
                sqlOutput = sqlInput.Substring(0, indexOpenBracket) + "({0}) VALUES ({1})";
    
                // Remove INSERT INTO [COLUMN] from sqlInput
                sqlInput = sqlInput.Substring(indexOpenBracket, sqlInput.Length - indexOpenBracket);
    
                int indexCloseBracket = sqlInput.IndexOf(')');
    
                // Get Coumn1,Column2,... 
                string tmpColumns = sqlInput.Substring(1, indexCloseBracket - 1);
    
                // Split to get all columns
                List<string> columns = tmpColumns.Split(',').ToList();
    
                // Remove Coumn1,Column2,... from sqlInput
                sqlInput = sqlInput.Substring(indexCloseBracket, sqlInput.Length - indexCloseBracket);
    
                indexOpenBracket = sqlInput.IndexOf('(');
    
                // Remove VALUES from sqlInput
                sqlInput = sqlInput.Substring(indexOpenBracket, sqlInput.Length - indexOpenBracket);
    
                indexCloseBracket = sqlInput.IndexOf(')');
    
                // Get values to insert from sqlInput
                string tmpValues = sqlInput.Substring(1, indexCloseBracket - 1);
    
                // Split to get all values
                List<string> values = tmpValues.Split(',').ToList();
    
                // remove the columns and values that are no longer needed
                foreach (string columnToRemove in columnssToRemove)
                {
                    int indexToRemove = columns.IndexOf(columnToRemove);
                    columns.RemoveAt(indexToRemove);
                    values.RemoveAt(indexToRemove);
                }
    
                // insert the columns and values into the sqlOutput
                sqlOutput = string.Format(sqlOutput, string.Join(", ", columns.ToArray()), string.Join(", ", values.ToArray()));
                return sqlOutput;
            }
        }
    }
