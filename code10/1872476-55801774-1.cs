    var query = (from users in _ctx.Users
                         join hCustomer in _ctx.HumanCustomers on users.Id equals hCustomer.UserId
                         join cCustomer in _ctx.CompanyCustomers  on users.Id equals cCustomer.UserId
                         select new MyClass
                         {
                             Id = users.Id,
                             Mobile = users.Mobile,
                             LastName = hCustomer.LastName,
                             Name = hCustomer.Name,
                             CompanyName = cCustomer.CompanyName
                         });
