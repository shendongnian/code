    private void addParagraphsQuery(DetachedCriteria sourceQuery, List<ParagraphContentArgument> paragraphsArguments)
    {
        DetachedCriteria dc;
        Conjunction conjunction = Restrictions.Conjunction();
        string alias = string.Empty;
        if (paragraphsArguments != null && paragraphsArguments.Count > 0)
        {
            for (int i = 0; i < paragraphsArguments.Count; i++)
            {
                alias = "p" + i.ToString();
                dc = DetachedCriteria.For<Document>().SetProjection(Projections.Id());
                dc.CreateAlias("paragraphList", alias);
                dc.Add(Restrictions.Eq(alias + ".paragraphSectionTemplate", paragraphsArguments[i].ParagraphTemplate));
                dc.Add(Restrictions.Like(alias + ".content", paragraphsArguments[i].Argument, MatchMode.Anywhere));
                conjunction.Add(Property.ForName("id").In(dc));
            }
        }
        sourceQuery.Add(conjunction);
    }
