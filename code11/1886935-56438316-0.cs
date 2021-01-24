    .QueryOver<Foo>(() => foo)
    .Where(Restrictions
        .Or(
            Restrictions.Where(() => foo.Name.IsInsensitiveLike(q)),
            Subqueries
                .WhereProperty(() => foo.ID)
                    .In(QueryOver.Of<Bar>(() => bar)
                        .Where(() => bar.Name.IsInsensitiveLike(q))
                        .Select(y => bar.Foo.ID)
                    )
        )
    )
