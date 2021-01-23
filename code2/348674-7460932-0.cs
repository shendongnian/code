    void PrepareTimers() {
        var timer1 = new Timer();
        timer1.Interval = 5000;
        timer1.Elapsed += (sn, ea) => { TimerAction(100); };
        timer1.Start();
    
        var timer2 = new Timer();
        timer2.Interval = 5000;
        timer2.Elapsed += (sn, ea) => { TimerAction(103); };
        timer2.Start();
    
        // etc
    }
    
    void TimerAction(int flag) {
        SqlCommand cmd = new SqlCommand(
    		"SELECT * FROM Customers WHERE flag = @flag", _connection);
        SqlParameter param  = new SqlParameter();
        param.ParameterName = "@flag";
        param.Value = flag;
        cmd.Parameters.Add(param);
    
        // execute query
    }
