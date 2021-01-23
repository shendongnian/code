           Excel.Worksheet activeSheet;
    		Excel.Range activeRange;
            public virtual object[,] RangeArray {
    			get { return ActiveRange.Value; }
    		}
    		public virtual int ColumnCount {
    			get { return RangeArray.GetLength(1); }
    		}
    		public virtual int RowCount {
    			get { return RangeArray.GetLength(0); }
    		}
    		public virtual int LastRow {
    			get { return RowCount; }
    		}
 
