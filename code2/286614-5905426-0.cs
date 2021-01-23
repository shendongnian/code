    var query = (from t in foo
                             group t by new {t.PO, t.Line}
                             into grp
                                 select new
                                            {
                                                grp.Key.PO,
                                                grp.Key.Line,
                                                QTY = grp.Sum(t => t.QTY)
                                            }).ToList()
