    public LastCheckInfo GetLastCheckInfo(...){
    if (reader["LastCheck"] != DBNull.Value)
    {
        return new LastCheckInfo(Convert.ToDateTime(reader["LastCheck"], "");
    }
    else
    {                         
        return new LastCheckInfo(DateTime.Min, "Failed to parse/get LastCheck Date") ;
    }
    
    }
