            Microsoft.Office.Interop.Excel.Range range = myworksheet.UsedRange;
            //Start iterating from 1 not zero, 1 is the first row after notation of the current coloumn
            for (int i = 1; i < range.Rows.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myrange = myworksheet.get_Range(/*your column letter, ex: "A" or "B"*/ + start.ToString(), System.Reflection.Missing.Value);
                string temp = myrange.Text;
                if(temp.Contains("YES"))
                    //Do your YES logic
                else if(temp.Contains("NO"))
                    //Do your No Logic
            }
