    class RentOrder
    {
        public DateTime StartDate 
        { 
          get { return _startDate }; 
          set 
          {
              if (value >= _endDate)
                  throw new Exception("Start Date cannot be greater than End Date");
              _startDate = value; 
          };
        }
        private DateTime _startDate;
        public DateTime EndDate
        { 
          get { return _endDate}; 
          set 
          {
              if (value <= _startDate)
                  throw new Exception("End Date cannot be less than Start Date");
              _endDate = value; 
          };
        }
        private DateTime _endDate;
    }
