    var results = (
            from r in RequestEntries
            group r by new
            {
                r.RequestId, r.RequestedDate
            } into g
            select new RequestWithApprover(){
                RequestId = g.Key.RequestId, 
                RequestedDate = g.Key.RequestedDate, 
                ApproverUserIds = g.Select(c => c.ApproverUserId).ToList(), 
                RequestApprovers = g.Select(c => new RequestApprover(){
                    ApproverUserName = c.ApproverUserName, 
                    ApproverUserId = c.ApproverUserId
                    }).ToList(), 
                RequestAuthorizers = g.
                    GroupBy(g => new {
                        g.Key.AuthorizerUserName, 
                        g.Key.AuthorizerUserId }).
                    Select(c => new RequestAuthorizer(){
                    AuthorizerUserName = c.AuthorizerUserName, 
                    AuthorizerUserId = c.AuthorizerUserId
                    }).ToList()
                }).ToList();
