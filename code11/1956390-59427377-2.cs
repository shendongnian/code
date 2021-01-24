    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    public static class DataGridMiscHelpers
    {
        /// <summary>
        /// Finds the visual parent of the given object
        /// </summary>
        /// <param name="originalSource">The original source.</param>
        /// <returns></returns>
        public static DependencyObject FindVisualParentAsDataGridSubComponent(
            DependencyObject originalSource)
        {
            // iteratively traverse the visual tree
            while ((originalSource != null) 
                && !(originalSource is DataGridCell) 
                && !(originalSource is DataGridColumnHeader) 
                && !(originalSource is DataGridRow))
            {
                if (originalSource is Visual || originalSource is Visual3D)
                {
                    originalSource = VisualTreeHelper.GetParent(originalSource);
                }
                else
                {
                    // If we're in Logical Land then we must walk 
                    // up the logical tree until we find a 
                    // Visual/Visual3D to get us back to Visual Land.
                    originalSource = LogicalTreeHelper.GetParent(originalSource);
                }
            }
            return originalSource;
        }
        /// <summary>
        /// Finds the cell and row data for the given source.
        /// </summary>
        /// <param name="originalSource">The original source.</param>
        /// <param name="cell">The cell.</param>
        /// <param name="row">The row.</param>
        public static void FindCellAndRow(DependencyObject originalSource, 
            out DataGridCell cell, out DataGridRow row)
        {
            cell = originalSource as DataGridCell;
            if (cell == null)
            {
                row = null;
                return;
            }
            // Walk the visual tree to find the cell's parent row.
            while ((originalSource != null) && !(originalSource is DataGridRow))
            {
                if (originalSource is Visual || originalSource is Visual3D)
                {
                    originalSource = VisualTreeHelper.GetParent(originalSource);
                }
                else
                {
                    // If we're in Logical Land then we must walk up the logical tree 
                    // until we find a Visual/Visual3D to get us back to Visual Land.
                    // See: http://www.codeproject.com/Articles/21495/Understanding-the-Visual-Tree-and-Logical-Tree-in
                    originalSource = LogicalTreeHelper.GetParent(originalSource);
                }
            }
            row = originalSource as DataGridRow;
        }
    }
