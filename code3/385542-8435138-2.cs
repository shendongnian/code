    public void SaveOrUpdate(ISession session, TaxAuditorSettings settings)
    {
        using (var tx = session.BeginTransaction())
        {
            // get whats in the database first because we dont have change tracking
            var enabledIds = session
                .CreateSqlQuery("SELECT * FROM TAX_AUDITOR_ALLOWED_COMPANIES")
                .Future<int>();
            var savedMonths = session
                .CreateSQLQuery("SELECT MONTH_NUMBER, YEAR FROM TAX_AUDITOR_ALLOWED_MONTHS")
                .SetResultTransformer(new MonthResultTransformer())
                .Future<Month>();
            foreach (var id in settings.AllowedVgs.Except(enabledIds))
            {
                session.CreateSqlQuery("INSERT INTO TAX_AUDITOR_ALLOWED_COMPANIES Values (:Id)")
                    .SetParameter("id", id).ExecuteUpdate();
            }
            foreach (var month in settings.AllowedMonths.Except(savedMonths))
            {
                session.CreateSqlQuery("INSERT INTO TAX_AUDITOR_ALLOWED_MONTHS Values (:number, :year)")
                    .SetParameter("number", month.Number)
                    .SetParameter("year", month.Year)
                    .ExecuteUpdate();
            }
            tx.Commit();
        }
    }
