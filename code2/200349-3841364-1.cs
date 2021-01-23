       1: public IList<Call> GetCallsByDateWithLinq(DateTime beginDate, int interpreterId)
       2: {
       3:     var query = from call in Session.Linq<Call>()
       4:                     where call.StartTime > beginDate
       5:                         && (call.EndTime == null || call.EndTime < DateTime.Now )
       6:                         && call.Interpreter.Id == interpreterId
       7:                     orderby call.StartTime descending, call.Customer.Name
       8:                     select call;
       9:
      10:     return query.ToList();
      11: }
