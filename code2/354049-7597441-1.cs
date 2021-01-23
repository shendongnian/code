            string[] cols = fileLine.Replace(", ", "|").Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (cols.Length == 3)
            {
                // the line contains 3 columns
                string col1 = cols[0];
                string col2 = cols[1];
                string col3 = cols[2];
            }
            else
            {
                // not valid
            }
