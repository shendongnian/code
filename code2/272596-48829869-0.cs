    // MakeSortable extension. 
    // this will make any enumerable collection sortable on a datagrid view.  
    
    //
    // BEGIN MAKESORTABLE - Mark A. Lloyd
    //
    // Enables sort on all cols of a DatagridView 
    //
    
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        public static class DataGridViewExtensions
        {
        public static void MakeSortable<T>(
            this DataGridView dataGridView, 
            IEnumerable<T> dataSource,
            SortOrder defaultSort = SortOrder.Ascending, 
            SortOrder initialSort = SortOrder.None)
        {
            var sortProviderDictionary = new Dictionary<int, Func<SortOrder, IEnumerable<T>>>();
            var previousSortOrderDictionary = new Dictionary<int, SortOrder>();
            var itemType = typeof(T);
            dataGridView.DataSource = dataSource;
            foreach (DataGridViewColumn c in dataGridView.Columns)
            {
                object Provider(T info) => itemType.GetProperty(c.Name)?.GetValue(info);
                sortProviderDictionary[c.Index] = so => so != defaultSort ? 
                    dataSource.OrderByDescending<T, object>(Provider) : 
                    dataSource.OrderBy<T,object>(Provider);
                previousSortOrderDictionary[c.Index] = initialSort;
            }
            async Task DoSort(int index)
            {
                switch (previousSortOrderDictionary[index])
                {
                    case SortOrder.Ascending:
                        previousSortOrderDictionary[index] = SortOrder.Descending;
                        break;
                    case SortOrder.None:
                    case SortOrder.Descending:
                        previousSortOrderDictionary[index] = SortOrder.Ascending;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                IEnumerable<T> sorted = null;
                dataGridView.Cursor = Cursors.WaitCursor;
                dataGridView.Enabled = false;
                await Task.Run(() => sorted = sortProviderDictionary[index](previousSortOrderDictionary[index]).ToList());
                dataGridView.DataSource = sorted;
                dataGridView.Enabled = true;
                dataGridView.Cursor = Cursors.Default;
            }
            dataGridView.ColumnHeaderMouseClick+= (object sender, DataGridViewCellMouseEventArgs e) => DoSort(index: e.ColumnIndex);
        }
    }
