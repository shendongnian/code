csharp
string[] columnNames = (model
                    .FirstOrDefault(t => t is ColumnConcatenatingTransformer) as ColumnConcatenatingTransformer)
                    ?.Columns
                    ?.FirstOrDefault(c => c.outputColumnName == "Features")
                    .inputColumnNames;
Console.WriteLine(String.Join(", ", columnNames));
