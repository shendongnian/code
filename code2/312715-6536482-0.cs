        public Double Lat
        {
            get
            {
                return this._lat;
            }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90 degrees inclusive.");
                }
                this._lat= value;
            }
        }
        public Double Lng
        {
            get
            {
                return this._lng;
            }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180 and 180 degrees inclusive.");
                }
                this._lng= value;
            }
        }
