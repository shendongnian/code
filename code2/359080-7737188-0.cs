        Dictionary<string, int> dicSum = new Dictionary<string, int>();
        foreach (DataRow row in dt.Rows)
        {
            string group=row["Group"].ToString();
            int rate=Convert.ToInt32(row["Rate"]);
            if (dicSum.ContainsKey(group))
                dicSum[group] += rate;
            else
                dicSum.Add(group, rate);
        }
        foreach (string g in dicSum.Keys)
            Console.WriteLine("SUM({0})={1}", g, dicSum[g]);
