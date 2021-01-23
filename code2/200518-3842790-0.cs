    private static IEnumerable<DataRow> GetRow<FType>(string Tablename, string Fieldname, FType match)
    {
        IEqualityComparer<FType> comp = EqualityComparer<TField>.Default;
        return dataSet.Tables[Tablename]
            .AsEnumerable()
            .Where(comp.Equals(row.Field<FType>(Fieldname), match));
    }
