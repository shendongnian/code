    var groupedData = joinedRows
    	.GroupBy(arg => new { TorqueGroupKey = arg.Torque / 100, SpeedGroupKey = Math.Floor((arg.Speed) / 500) })
    	.Select(g => new
    	{
    		g.Key.TorqueGroupKey,
    		g.Key.SpeedGroupKey,
    		Minutes = g.Count()
    	});
