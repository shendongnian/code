     using (var context = new TicketingContext())
     {
         var res = context.A.GroupJoin(context.B,
                    a => a.IDA,
                    b => b.IDA,
                    (a, bList) => new { a, Result = new Result { Strings = bList.ToList() } }
                    ).ToList();
     }
