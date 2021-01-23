    sb.Append("Readings:[");
    
    bool isFirst = true;
    foreach (var reading in lake.Reading)
    {
        if( isFirst == false )
        {
            sb.Append( "," );
        }
        isFirst = false;
        sb.Append("[");
        sb.Append("\"");
        sb.Append(reading.DateTime.ToString("dd-MMM-yy"));
        sb.Append("\"");
        sb.Append(",");
        sb.Append(reading.Level);
        sb.Append("]");
    }
    sb.Append("]");
