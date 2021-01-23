    public class Info
    {
        private string _status;
        private string _committee;
        private string _comName;
        private string _dateperiod;
        public string getFormattedvalue
        {
            get 
            {
                return _status +", "+
                    _committee +", "+
                    _comName;
            }
        }
        public string formattedDate
        {
            get
            {
                return _dateperiod;
            }
        }
        public Info(string input)
        {
            string[] s = input.Split(',');
            _status = s[0];
            _committee = s[1];
            _comName = s[2];
            _dateperiod = s[3];
        }
  
    }
 
