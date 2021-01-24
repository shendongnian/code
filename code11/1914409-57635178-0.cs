        protected override IQueryable<SolicitudPrestamo> CreateFilteredQuery(PagedAndSortedRequest input)
        {
            return Repository.GetAll().
                            WhereIf(!input.Filter.IsNullOrWhiteSpace(), x =>
                                x.Identificador.StartsWith(input.Filter, StringComparison.CurrentCultureIgnoreCase) ||
                                x.FormaPago.StartsWith(input.Filter, StringComparison.CurrentCultureIgnoreCase) ||
                                x.Proposito.StartsWith(input.Filter, StringComparison.CurrentCultureIgnoreCase) ||
                                x.Referencia.StartsWith(input.Filter, StringComparison.CurrentCultureIgnoreCase)
                            );
        }
