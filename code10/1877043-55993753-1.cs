    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    internal class DGVSearcher
    {
        DataGridView dgv = null;
        string m_SearchCriteria = string.Empty;
        int m_ColumnIndex = -1;
        IEnumerator<DataGridViewRow> m_enumerator = null;
        public DGVSearcher(DataGridView dataGridView) => this.dgv = dataGridView;
        private List<DataGridViewRow> cached { get; set; } new List<DataGridViewRow>();
        public bool Search(int cellIndex, string criteria, bool selectRow)
        {
            if (string.IsNullOrEmpty(criteria)) return false;
            bool result = true;
            if (criteria.Equals(this.m_SearchCriteria) && this.m_ColumnIndex == cellIndex) {
                if (!this.m_enumerator.MoveNext())
                {
                    this.m_enumerator.Reset();
                    this.m_enumerator.MoveNext();
                }
                SetSelectedRow(this.m_enumerator.Current as DataGridViewRow, selectRow);
            }
            else {
                this.m_SearchCriteria = criteria;
                this.m_ColumnIndex = cellIndex;
                result = RebuildCachedCollection(cellIndex);
            }
            return result;
        }
        private bool RebuildCachedCollection(int cellIndex)
        {
            bool result = false;
            if (cached.Count > 0) cached.Clear();
            cached = this.dgv.Rows.OfType<DataGridViewRow>()
                                  .Where(r => r.Cells[cellIndex].FormattedValue.ToString()
                                  .Contains(this.m_SearchCriteria)).ToList();
            if (cached.Count() > 0) {
                this.m_enumerator = cached.GetEnumerator();
                this.m_enumerator.MoveNext();
                SetSelectedRow(this.m_enumerator.Current as DataGridViewRow, true);
                result = true;
            }
            return result;
        }
        private void SetSelectedRow(DataGridViewRow row, bool setSelected)
        {
            row.Selected = setSelected;
            this.dgv.FirstDisplayedScrollingRowIndex = row.Index;
            if (!setSelected) this.dgv.CurrentCell = this.dgv[0, row.Index];
        }
    }
