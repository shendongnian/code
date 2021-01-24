    static Section Map( IEnumerable<Csv1Data> source )
    {
        return new Section
        {
            Rows = source
                .Select( e => new SectionRow
                {
                    Code = e.Code,
                    Value = e.S1,
                    Columns = new List<SectionRowCol>
                    {
                        new SectionRowCol{ Code = 5, Value = e.Col5, },
                        new SectionRowCol{ Code = 6, Value = e.Col6, },
                        new SectionRowCol{ Code = 7, Value = e.Col7, },
                        new SectionRowCol{ Code = 8, Value = e.Col8, },
                    }
                } )
                .ToList(),
        };
    }
