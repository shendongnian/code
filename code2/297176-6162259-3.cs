    var groupVars = GetObjectFields(NewMainGroup);
	foreach(var gv in groupVars) {
		Response.Write(<BR>MainGroupName=  " + gv.Key + " Value=  " + gv.Value.ToString());
		var subGroupVars = GetObjectFields(gv.Value);
		foreach(var sgv in subGroupVars) {
			Response.Write(<BR>SubGroupName=  " + sgv.Key + " Value=  " + sgv.Value.ToString());
		}
	}
