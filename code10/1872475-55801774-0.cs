    var query = (from users in _ctx.Users
                         join hCustomer in _ctx.HumanCustomers on users.Id equals hCustomer.UserId
                         join cCustomer in _ctx.CompanyCustomers  on users.Id equals cCustomer.UserId
                         select new MyClass
                         {
                             users.Id,
                             users.Mobile,
                             hCustomer.LastName,
                             hCustomer.Name,
                             cCustomer.CompanyName
                         });
