    var ans = Scheduled
                .Select(s => new ClassPeriod { From = s.From, To = s.To })
                .Concat(
                    Registered.Select(r =>
                        new ClassPeriod {
                            From = Scheduled.Where(a => a.Between(r.From)).Select(a => a.To).DefaultIfEmpty(r.From).Max(),
                            To = Scheduled.Where(a => a.Between(r.To)).Select(a => a.From).DefaultIfEmpty(r.To).Min()
                        }
                    )
                )
                .Where(p => p.From < p.To)
                .OrderBy(cp => cp.From).ThenBy(cp => cp.To);
