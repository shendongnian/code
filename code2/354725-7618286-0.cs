    public class Filter
    {
        public virtual string GetDescription()
        {
            return "filter";
        }
    }
    public class DistrFilter : Filter
    {
        public override string GetDescription()
        {
            return "distr filter";
        }
    }
    public class ReportFilter : Filter
    {
        public override string GetDescription()
        {
            return "report filter";
        }
    }
    public class FilterService
    {
        public string GetDescription<T>( List<T> filters )
            where T: Filter
        {
            if ( filters.Count == 0 )
                return String.Empty;
            StringBuilder s = new StringBuilder( "<ul>" );
            foreach ( T f in filters )
                s.AppendFormat( "<li>{0}</li>", f.GetDescription() );
            s.Append( "</ul>" );
            return s.ToString();
        }
    }
