    var p = new DynamicParameters(); 
    p.Add("Id", 1);
    p.Add("Message",direction: ParameterDirection.Output);
    p.Add("rval",direction: ParameterDirection.ReturnValue);
    var grid = cnn.QueryMultiple("spGetOrder", p, commandType: CommandType.StoredProcedure);
    var order = grid.Read<Order,User,Order>((o,u) => {o.Owner = u; return o;});
    order.Items = grid.Read<OrderItems>(); 
    var returnVal = p.Get<int>("rval"); 
    var message = p.Get<string>("message"); 
