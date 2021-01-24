c#
long GetMatchId(dataReader)
{
    var id = DataHelper.GetLong(dataReader, "Match");
    return (id > 0 ? id : DataHelper.GetLong(dataReader, "ID"));
}
return new Match {
    Id = GetMatchId(dataReader)
};
