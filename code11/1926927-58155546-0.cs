    querySelection = (from problems in db.Problems
                  join response in db.Response on problems.id equals response.Query_Id
                  join order in db.Msg_Orders on query.id equals order.query_id
                  join seen_status in db.Seen_Status on order.Order_id equals seen_status.Order_id
                  group new { problems, response, order ,seen_status }
                    by new
                    {
						problems.Id,
                        problems.Problem_State,
						problems.Created_Date,
						response.Response,
						seen_status.User_Seen_Status
                    } into grp
                  orderby grp.Key.Id descending
                  select new QuerySelection
                  {
                      Id = grp.Key.Id,
					  Problem_State = grp.Key.Problem_State,
					  Created_Date = grp.Key.Created_Date,
					  Response = grp.Key.Response,
                      TotalResp = grp.Count(x => x.seen_status.user_seen == 0) // Counting total number of responses
                  }
                  ).ToList();
