	var context = new Entities();
	var complaints = from c in context.Complaints
					 join s in context.Statuses on c.Status equals s.Id
					 join service in context.SERVICES on c.ServiceId equals service.Id
					 join u in context.Users on c.CreatedBy equals u.UserId
                     from technician in context.Users.Where(technician => technician.UserId == c.AssignedTo).DefaultIfEmpty()
				     select new
					 {
						 c.Id,
						 c.Status,
						 s.Name,
						 c.ServiceId,
						 Service = service.Name,
						 c.Title,
						 c.Customer,
						 c.Description,
						 c.CreatedDate,
						 c.CreatedBy,
						 Author = u.Username,
						 c.AssignedBy,
						 c.AssignedTo,
						 Technician = technician.Username,
						 c.AssignedDate
					 };
	
