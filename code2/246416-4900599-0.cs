    returnRecords.AddRange((from r in pjRepository.Records
                                join m in memberRepository.Members on r.SID equals m.MemberId.ToString()
                                where r.TransactionDate >= startDate && r.TransactionDate <= endDate
                                select new { r, m }).AsEnumerable().Select(x =>
                                {
                                    GenericRecord g = (GenericRecord)x.r;
                                    g.Member = x.m;
                                    return g;
                                }));
