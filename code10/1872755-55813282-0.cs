    public class ProjectEffortTable : DataTable
    {
        public ProjectEffortTable() : base() { }
        public ProjectEffortTable(String TableName) : base(TableName) { }
        protected ProjectEffortTable(System.Runtime.Serialization.SerializationInfo Info, System.Runtime.Serialization.StreamingContext Context) : base (Info, Context) { }
        public ProjectEffortTable(String TableName, String TableNamespace) : base(TableName, TableNamespace) { }
        protected override Type GetRowType()
        {
            return typeof(ProjectEffortRow);
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder Builder)
        {
            return new ProjectEffortRow(Builder);
        }
        public new ProjectEffortTable GetChanges()
        {
            var Changes = Clone() as ProjectEffortTable;
            foreach (ProjectEffortRow CurrentRow in Rows)
            {
                if ((CurrentRow.RowState != DataRowState.Unchanged) && (!CurrentRow.IsSum))
                {
                    Changes.ImportRow(CurrentRow);
                }
            }
            if (Changes.Rows.Count == 0)
            {
                Changes = null;
            }
            return Changes;
        }
        public new ProjectEffortTable GetChanges(DataRowState RowStates)
        {
            var Changes = Clone() as ProjectEffortTable;
            foreach (ProjectEffortRow CurrentRow in Rows)
            {
                if ((CurrentRow.RowState == RowStates) && (!CurrentRow.IsSum))
                {
                    Changes.ImportRow(CurrentRow);
                }
            }
            if (Changes.Rows.Count == 0)
            {
                Changes = null;
            }
            return Changes;
        }
        public void AddSumRow()
        {
            // add line with sum for each month column
            var SumRow = NewRow() as ProjectEffortRow;
            SumRow.IsSum = true;
            Rows.Add(SumRow);
            RecalculateSums();
        }
        public Boolean HasSumRow()
        {
            var SumRowFound = false;
            if ((Rows[Rows.Count - 1] as ProjectEffortRow).IsSum)
            {
                SumRowFound = true;
            }
            return SumRowFound;
        }
        public void RemoveSumRow()
        {
            if (HasSumRow())
            {
                Rows[Rows.Count - 1].Delete();
            }
        }
        private void RecalculateSums()
        {
            if (!HasSumRow())
            {
                throw new ApplicationException("Recalculation of sum triggered without sum row being present");
            }
            foreach (DataColumn Column in Columns)
            {
                Decimal Sum = 0;
                foreach (ProjectEffortRow CurrentRow in Rows)
                {
                    if ((CurrentRow[Column] is Double) && (!CurrentRow.IsSum))
                    {
                        Sum += Convert.ToDecimal(CurrentRow[Column]);
                    }
                }
                Rows[Rows.Count - 1][Column] = Decimal.Truncate(Sum);
            }
        }
    }
