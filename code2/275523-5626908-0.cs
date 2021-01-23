        bool AreEqual(DataTable d1, DataTable d2)
        {
            if (d1.Rows.Count != d2.Rows.Count)
                return false;
            for (int i = 0; i < d1.Rows.Count; i++)
            {
                var d1Row = d1.Rows[i];
                var d2Row = d2.Rows[i];
                for (int j = 0; j < d1Row.ItemArray.Count(); j++)
                {
                    if (!d1Row[j].Equals(d2Row[j]))
                       return false;
                }
            }
            return true;
        }
