    var _sqlString = new StringBuilder();
    foreach(string reelid in unValidatedFeedersOnMachine.Keys) {                     
    	if(_sqlString.ToString().Length != 0) {
    		_sqlString.Appened(" or ")
    	}
    	_sqlString.Append("CompID = '").Append(reelid).Append("' ");
    }
