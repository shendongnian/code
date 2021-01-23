    Session.QueryOver<ConnectorLogEntry>()
        .SelectList(list =>
            list.SelectGroup(m => m.DepartmentName)
                .WithAlias(() => dto.Department)
                .Select(Projections.SqlFunction(
                    new VarArgsSQLFunction("(", "*", ")"),
                    NHibernateUtil.Int32,
                    Projections.Sum<ConnectorLogEntry>(m => m.TotalPages),
                    Projections.Sum<ConnectorLogEntry>(m => m.ColorPages)))
                .WithAlias(() => dto.TotalColorPercentage))
        .TransformUsing(Transformers.AliasToBean<DepartmentConsumption>());
