    (from a in context.Table1
     join b in context.Table2 on a.PersonalID equals b.ID
     select new { A=a, B=b } into joined
     group joined by new { joined.A.PersonalID, joined.B.Name, joined.B.Surname } into grouped
     select grouped.Select(g => new { 
                                        DateField= g.A.Datefield,
                                        Name = g.B.Name,
                                        Surname = g.B.Surname,
                                        PagaBruto = g.A.Sum(i => i.Bruto)
                                    })).SelectMany(g => g);
