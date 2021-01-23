    public vkMessages(string kto, DateTime date_time, string text, bool read_state)
        : this(kto, date_time, text, read_state, false) { }
    public vkMessages(string kto, DateTime date_time,
                      string text, bool read_state,string in_or_out)
    {
        InOrOut = in_or_out;
        Kto = kto;
        Date_Time = date_time;
        TexT = text;
        Read_State = read_state; 
    }
