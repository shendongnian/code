                                         from r in db.btRequests
                                         select new Models.BT.Request {
                                             ID = r.ID,
                                             Date = r.DateTime,
                                             StatusCode = 3,
                                             Status = r.Status
                                         };
