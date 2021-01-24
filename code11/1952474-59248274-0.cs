    using (var connection = new SqlConnection(_sqlConnectionString))
    {
        var results = connection.Query<OrderDTO>(query).ToList();
        if(results.Paymethod ==null){
              results.Paymethod = PayMethod.Paymethod.iDeal
        }
        return results;
    }
