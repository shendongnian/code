    var parameters = new Dictionary<string, object>() {
    	{ "method", "events.invite" },
    	{ "eid", IdEvent },
    	{ "uids", "100000339376504" }
    };
    var users = app.Api(parameters);
