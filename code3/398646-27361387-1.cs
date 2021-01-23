    var result = session.CreateSQLQuery("exec GetMemberGameActivity :mToken, :StartDate, :EndDate")
                        .SetResultTransformer(Transformers.AliasToBean<GameActivity>())
                        .SetParameter("mToken", token)
                        .SetParameter("StartDate", startDate)
                        .SetParameter("EndDate", endDate)
                        .List<GameActivity>().ToList();
