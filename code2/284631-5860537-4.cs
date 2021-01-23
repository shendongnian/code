    IDictionary<MyEnum, int> CountOccurrences(IEnumerable<MyEnum> values)
    {
        return (from e in values group e by e).ToDictionary(grp => grp.Key, grp => grp.Count());
    }
    var solutions = from p1 in CountOccurrences(listOne.Values)
                    where IsCandidate(p1)
                    from p2 in CountOccurrences(listTwo.Values)
                    where IsCandidate(p1, p2)
                    from p3 in CountOccurrences(listThree.Values)
                    where IsCandidate(p1, p2, p3)
                    from p4 in CountOccurrences(listFour.Values)
                    where IsCandidate(p1, p2, p3, p4)
                    from p5 in CountOccurrences(listFive.Values)
                    where IsCandidate(p1, p2, p3, p4, p5)
                    from p6 in CountOccurrences(listSix.Values)
                    where IsCandidate(p1, p2, p3, p4, p5, p6)
                    from p7 in CountOccurrences(listSeven.Values)
                    where IsSolution(p1, p2, p3, p4, p5, p6, p7)
                    select new {
                        E1 = p1.Key,
                        E2 = p2.Key,
                        E3 = p3.Key,
                        E4 = p4.Key,
                        E5 = p5.Key,
                        E6 = p6.Key,
                        E7 = p7.Key,
                        Times = p1.Value * p2.Value * p3.Value * p4.Value * p5.Value * p6.Value * p7.Value
                    };
