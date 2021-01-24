            var benchmark1Returns = GetViewService<MV_INDEX_PERFORMANCE>()
                .Where(x => x.Mtd != null && x.IndexId == benchMark1)
                .Join(periodTuples,
                    b1r => new { x = b1r.PriceDate.Year, y = b1r.PriceDate.Month },
                    tuple => new { x = tuple.Item1, y = tuple.Item2 },
                    (b, t) => b.Mtd);
