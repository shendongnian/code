    using Microsoft.Office.Server.Search.Query;
    // ...
    Query query = new FullTextSqlQuery(site);
    query.StartRow = x;
    query.RowLmit = 10;
