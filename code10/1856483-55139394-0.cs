    interface IDbItem
    {
        int Id {get; }      // no need to ever change the primary key
        DateTime? Obsolete {get; set;}
    }
