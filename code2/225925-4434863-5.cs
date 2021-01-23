    public class RecordUrlNameComparer: IComparer<RecordUrl>
    {
        Int32 System.Collections.Generic.IComparer<RecordUrl>.Compare( RecordUrl x, RecordUrl y )
        {
            return new System.Collections.Comparer( System.Globalization.CultureInfo.CurrentCulture ).Compare( x.Name, y.Name );
        } 
    } // public class RecordUrlNameComparer: IComparer<RecordUrl> 
