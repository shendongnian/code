    // Using dynamic (.Net 4.0 only)
    var app = new FacebookApp();
    dynamic me = app.Get("me");
    string firstName = me.first_name;
    string lastName = me.last_name;
    string email = me.email;
    
    // Using IDictionary<string, object> (.Net 3.5, .Net 4.0, WP7)
    var app = new FacebookApp();
    var me = (IDicationary<string,object>)app.Get("me");
    string firstName = (string)me["first_name"];
    string lastName = (string)me["last_name"];
    string email = (string)me["email"];
