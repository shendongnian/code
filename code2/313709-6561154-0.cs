    var result = from u in db.Users
                  where u.UserID == user.Id
                  join p in db.Payments on u.Id equals p.UserId
                  join comm in db.TutorCourseCommissions 
                  on p.Id equals comm.PaymentId
                  group common.GetMonthName(comm.CoursePaidForMonthYear,true)
                  by new { User = u, Payment = p } into g
                  select new 
                  {
                     User = g.Key.User,
                     Payment = g.Key.Payment,
                     //...select out other properties here... 
                     Months = String.Join(", ", g.Distinct())
                  };
