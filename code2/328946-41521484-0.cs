            var personList = dbEntities.People.GroupBy(m => m.PersonType).Select(m => new { PersonType = m.Key, Count = m.Count() });
        }
        public void GroupBy2()
        {
            var personList = dbEntities.People.GroupBy(m => new { m.PersonType, m.FirstName }).Select(m => new { PersonType = m.Key, Count = m.Count() });
        }
        public void GroupBy3()
        {
            var personList = dbEntities.People.Where(m => m.EmailPromotion != 0).GroupBy(m => new { m.PersonType, m.FirstName }).Select(m => new { PersonType = m.Key, Count = m.Count() });
        }
        public void GroupBy4()
        {
            var personList = dbEntities.People.GroupBy(m => new { m.PersonType, m.FirstName }).Where(m => m.Count() > 70).Select(m => new { PersonType = m.Key, Count = m.Count() });
        }
        public void GroupBy5()
        {
            var personList = dbEntities.People
                .GroupBy(m =>
                    new
                    {
                        m.PersonType
                    }).Where(m => m.Count() > 70)
                        .Select(m =>
                            new
                            {
                                PersonType = m.Key,
                                Count = m.Count()
                            });
            var list1 = dbEntities.People.
                GroupBy(m => new { m.PersonType }).
                Select(m =>
                    new
                    {
                        Type = m.Key,
                        Count = m.Count()
                    })
                .Where(
                       m => m.Count > 70
                    && m.Type.PersonType.Equals("EM")
                    || m.Type.PersonType.Equals("GC"));
        }
        public void GroupBy6()
        {
            var list1 = dbEntities.People.
                GroupBy(m => new { m.PersonType, m.EmailPromotion }).Select(m =>
                    new
                    {
                        Type = m.Key,
                        Count = m.Count()
                    })
                .Where
                (
                    m => m.Count > 70 && m.Type.EmailPromotion.Equals(0) &&
                    (
                        m.Type.PersonType.Equals("EM") ||
                        m.Type.PersonType.Equals("GC")
                    ));
        }
        public void GroupBy7()
        {
            var list1 = dbEntities.People.
                GroupBy(m => m.PersonType).
                Select(c =>
                    new
                    {
                        Type = c.Key,
                        Total = c.Sum(p => p.BusinessEntityID)
                    });
        }
        public void GroupBy8()
        {
            var list1 = dbEntities.People.
                GroupBy(m => m.PersonType).
                Select(c =>
                    new
                    {
                        Type = c.Key,
                        Count = c.Count(),
                        Total = c.Sum(p => p.BusinessEntityID)
                    });
        }
        public void GroupBy9()
        {
            var list1 = dbEntities.People.
                GroupBy(m => m.PersonType).
                Select(c =>
                    new
                    {
                        Type = c.Key,
                        Max = c.Max(),
                    });
        }
