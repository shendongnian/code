     private int _totalTimeUnitId;
        public int TotalTimeUnitId
        {
            get
            {
                return _totalTimeUnitId;
            }
            set
            {
                _totalTimeUnitId = value;
                switch (_totalTimeUnitId)
                {
                    case 1:
                        TotalTimeUnit = "min";
                        break;
                    case 2:
                        TotalTimeUnit = "hour(s)";
                        break;
                    default:
                        TotalTimeUnit = string.Empty;
                        break;
                }
            }
        }
