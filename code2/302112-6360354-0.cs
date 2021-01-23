        int ProgressValue
        {
            get
            {
                int? Value = Cache["ProgressValue"] as int?;
                if (Value == null)
                {
                    //Set expiration time to 6 AM tomorrow.
                    DateTime ExpTime = DateTime.Now.Date.AddDays(1).AddHours(6);
                    Value = GetValueFromDB();
                    Cache.Insert("ProgressValue", Value, null, ExpTime, System.Web.Caching.Cache.NoSlidingExpiration);
                }
                return (int)Value;
            }
        }
