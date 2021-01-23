    sb.Append("Readings:[");
    Array list = late.Reading.ToArray();
                    for (int i=0;i<list.Length;i++)
                    {
                        var reading = list[i];
                        sb.Append("[");
                        sb.Append("\"");
                        sb.Append(reading.DateTime.ToString("dd-MMM-yy"));
                        sb.Append("\"");
                        sb.Append(",");
                        sb.Append(reading.Level);
                        sb.Append("]");
                        if (i!=list.Length-1)
                           sb.Append(",");
                    }
                sb.Append("]");
