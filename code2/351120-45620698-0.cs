        /// <summary>
        /// Compare a source and target datatables and return the row that are the same, different, added, and removed
        /// </summary>
        /// <param name="dtOld">DataTable to compare</param>
        /// <param name="dtNew">DataTable to compare to dtOld</param>
        /// <param name="dtSame">DataTable that would give you the common rows in both</param>
        /// <param name="dtDifferences">DataTable that would give you the difference</param>
        /// <param name="dtAdded">DataTable that would give you the rows added going from dtOld to dtNew</param>
        /// <param name="dtRemoved">DataTable that would give you the rows removed going from dtOld to dtNew</param>
    
    public static void GetTableDiff(DataTable dtOld, DataTable dtNew, ref DataTable dtSame, ref DataTable dtDifferences, ref DataTable dtAdded, ref DataTable dtRemoved)
        {
            dtAdded = dtOld.Clone();
            dtAdded.Clear();
            dtRemoved = dtOld.Clone();
            dtRemoved.Clear();
            dtDifferences = dtOld.AsEnumerable().Except(dtNew.AsEnumerable(), DataRowComparer.Default).CopyToDataTable<DataRow>();
            dtSame = dtOld.AsEnumerable().Intersect(dtNew.AsEnumerable(), DataRowComparer.Default).CopyToDataTable<DataRow>();
            foreach (DataRow row in dtDifferences.Rows)
            {
                if (dtOld.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray))
                    && !dtNew.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray)))
                {
                    dtRemoved.Rows.Add(row.ItemArray);
                }
                else if (dtNew.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray))
                    && !dtOld.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray)))
                {
                    dtAdded.Rows.Add(row.ItemArray);
                }
            }
        }
