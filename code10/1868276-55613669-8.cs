    using System;
    using System.Data;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        public class HighlighterConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values[1] is DataRow)
                {
                    var cell = (DataGridCell)values[0];
                    var row = (DataRow)values[1];
                    var columnName = cell.Column.SortMemberPath;
    
                    if (row[columnName].ToString() == "rouge" )
                        return Brushes.Red;
                    if (row[columnName].ToString() == "vert")
                        return Brushes.Green;
    
                }
                return SystemColors.AppWorkspaceColor;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new System.NotImplementedException();
            }
        }
    
    }
