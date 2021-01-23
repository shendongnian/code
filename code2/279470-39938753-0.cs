    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Data;
    namespace Converters
    {
        [ValueConversion(typeof(object[]), typeof(ListCollectionView))]
        public class IListToListCollectionViewConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var Length = values.Length;
                if (Length >= 1 && Length < 3)
                {
                    var IList = values[0] as IList;
                    var SortName = string.Empty;
                    if (Length > 1)
                        SortName = values[1].ToString();
                    var SortDirection = ListSortDirection.Ascending;
                    if (Length > 2)
                        SortDirection = values[2] is ListSortDirection ? (ListSortDirection)values[2] : (values[2] is string ? (ListSortDirection)Enum.Parse(typeof(ListSortDirection), values[2].ToString()) : SortDirection);
                    var Result = new ListCollectionView(IList);
                    Result.SortDescriptions.Add(new SortDescription(SortName, SortDirection));
                    return Result;
                }
                return null;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
