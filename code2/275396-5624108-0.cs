            var baseQuery = from co in collection where !co.IsVirtual select co; // base of query
            IOrderedEnumerable<Result> orderedQuery; // result of first ordering, must be of this type, so we are able to call ThenBy
            switch(CurrentDisplayMode) // use enum here
            { // primary ordering based on enum
                case CRSChartRankingGraphDisplayMode.Position: orderedQuery = baseQuery.OrderBy(co => co.Price);
                    break;
                case CRSChartRankingGraphDisplayMode.Grade: orderedQuery = baseQuery.OrderBy(co => co.TotalGrade);
                    break;
            }
            this.collectionCompleteSorted = orderedQuery.ThenBy(co => co.CurrentRanking).ToList(); // secondary ordering and conversion to list
