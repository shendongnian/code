    List<C> cList2 = ipData.GroupBy(x => x.ColC).Select(colC => new C
    {
        ColC = colC.Key,
        b = colC.GroupBy(colB => colB.ColB).Select(colB => new B
        {
            ColB = colB.Key,
            a = colB.Select(colA => new A
            {
                ColA = colA.ColA
            }).ToList()
        }).ToList()
    }).ToList();
