    var ans = Scheduled
                .Select(s => new ClassPeriod { From = s.From, To = s.To })
                .Concat(
                    Registered.SelectMany(r => {
                        var ans = new List<ClassPeriod>();
                        while (r.From < r.To) {
                            var pcp = new ClassPeriod {
                                From = Scheduled.Where(s => s.ContainsFrom(r)).Select(s => s.To).DefaultIfEmpty(r.From).Max(),
                                To = Scheduled.Where(s => s.ContainsTo(r)).Select(s => s.From).DefaultIfEmpty(r.To).Min()
                            };
                            var nexts = Scheduled.Where(s => pcp.ContainsFrom(s));
                            if (nexts.Any()) {
                                var nextTo = nexts.Min(s => s.From);
                                ans.Add(new ClassPeriod { From = pcp.From, To = nextTo });
                                r.From = nextTo;
                            }
                            else {
                                if (pcp.From < pcp.To)
                                    ans.Add(pcp);
                                break;
                            }
                        }
                        return ans;
                    })
                )
                .OrderBy(cp => cp.From).ThenBy(cp => cp.To);
