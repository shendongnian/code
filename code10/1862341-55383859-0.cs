    > public IEnumerable<TEntidade> ObterEntidadesPor(Expression<Func<TEntidade, bool>>
    > where)
    >         {
    >             return SessionNH.Query<TEntidade>().Where(where);
    >         }
