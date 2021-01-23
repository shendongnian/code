    		DataTable dt = yourData();
            StringBuilder csv = new StringBuilder();
			int dcCounter = 0;
			
            foreach (DataColumn dc in dt.Columns)
            {
                csv.Append(dc);
                if (dcCounter != dt.Columns.Count - 1)
                {
                    csv.Append(",");
                }
                dcCounter++;
            }
            csv.AppendLine();
            int numOfDc = dt.Columns.Count;
            foreach (DataRow dr in dt.Rows)
            {
                int colIndex = 0;
                while (colIndex <= numOfDc - 1)
                {
                    var colVal = dr[colIndex].ToString();
                    if (colVal != null && colVal != "")
                    {
                        DateTime isDateTime;
                        if (DateTime.TryParse(colVal, out isDateTime))
                        {
                            csv.Append(Convert.ToDateTime(colVal).ToShortDateString());
                        }
                        else
                        {
                            csv.Append(dr[colIndex]);
                        }
                    }
                    else
                    {
                        csv.Append("N/A");
                    }
                    if (colIndex != numOfDc - 1)
                    {
                        csv.Append(",");
                    }
                    colIndex++;
                }
                csv.AppendLine();
