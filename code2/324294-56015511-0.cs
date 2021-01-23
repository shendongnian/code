            // Convert array data into CSV format.
            // Modified from http://csharphelper.com/blog/2018/04/write-a-csv-file-from-an-array-in-c/.
            private string GetCSV(List<string> Headers, List<List<double>> Data)
            {
                // Get the bounds.
                var rows = Data[0].Count;
                var cols = Data.Count;
                var row = 0;
    
    
                // Convert the array into a CSV string.
                StringBuilder sb = new StringBuilder();
    
                // Add the first field in this row.
                sb.Append(Headers[0]);
    
                // Add the other fields in this row separated by commas.
                for (int col = 1; col < cols; col++)
                    sb.Append("," + Headers[col]);
    
                // Move to the next line.
                sb.AppendLine();
    
                for (row = 0; row < rows; row++)
                {
                    // Add the first field in this row.
                    sb.Append(Data[0][row]);
    
                    // Add the other fields in this row separated by commas.
                    for (int col = 1; col < cols; col++)
                        sb.Append("," + Data[col][row]);
    
                    // Move to the next line.
                    sb.AppendLine();
                }
    
                // Return the CSV format string.
                return sb.ToString();
            }
