        private int rowValue_;
        public object RowValue
        {
            get
            {
                return this.rowValue_;
            }
            set
            {
                var type = value.GetType();
                if (type == typeof(string))
                {
                    this.rowValue_ = Convert.ToInt32(value);
                }
                else if (type == typeof(int))
                {
                    this.rowValue_ = (int)value;
                }
                else
                {
                    throw new InvalidDataException(
                        "HandwritingData RowValue can only be string or int. 
                        Passed in parameter is typeof {0}",
                        value.GetType().ToString());
                }
            }
        }
