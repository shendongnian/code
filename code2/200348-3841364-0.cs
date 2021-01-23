       1: public IList<Call> GetCallsByDate(DateTime beginDate, int interpreterId)
       2: {
       3:     ICriteria criteria = Session.CreateCriteria(typeof(Call))
       4:         .CreateAlias("Customer", "Customer")
       5:         .Add(Restrictions.Gt("StartTime", beginDate))
       6:         .Add(
       7:            Restrictions.Or(
       8:                 Restrictions.Lt("EndTime", DateTime.Now), Restrictions.IsNull("EndTime")
       9:                 )
      10:             )
      11:         .Add(Restrictions.Eq("Interpreter.Id", interpreterId))
      12:         .AddOrder(Order.Desc("StartTime"))
      13:         .AddOrder(Order.Desc("Customer.Name"));
      14:
      15:     return criteria.List<Call>() as List<Call>;
      16: }
