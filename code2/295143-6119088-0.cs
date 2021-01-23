    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    
    namespace SO_Forms_Demo
    {
        class SumFifo
        {
    
            DataTable _dt;
    
            public SumFifo(DataTable dt)
            {
                _dt = dt;
            }
    
            public DataView GetAll()
            {
                return new DataView(_dt, null, null, DataViewRowState.CurrentRows);
            }
    
            public DataTable GetFIFO(string partNumber, int qty)
            {
                DataTable resultsTable = _dt.Clone();
    
                //the generic collection type that represents a FIFO relationship is a Queue
                Queue<DataRow> PartRows = new Queue<DataRow>(_dt.Select("partNumber = '" + partNumber + "'", "serialNumber"));
    
                //iterate through the queue adding rows and decreasing quantity till your requirment is met.
                foreach (DataRow row in PartRows)
                {
                    if (qty > 0)
                    {
                        resultsTable.ImportRow(row);
                        qty -= int.Parse(row["qty"].ToString());
                    }
                }
    
                return resultsTable;
            }
        }
    }
