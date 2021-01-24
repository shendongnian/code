var query = String.Format("SELECT ... where 1=1 ");
for (int 0 = 1; i < searchTerm.Count(); i++)
{
    query += $" and MySqlField like '%{{{i}}}%'";
}
var results = context.MySqlTable.FromSql(query, searchTerm.ToArray());
