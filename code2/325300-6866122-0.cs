    public class MeterValues
    {
        public static Dictionary<int, int> meterList =  new Dictionary<int, int>();
        public static int ReturnValue(int meterValue)
        {
            if (meterList.Count == 0)
                LoadValues();
            return meterList.ContainsKey(meterValue) ? meterList[meterValue] : dal.GetLastBalance(meterNumber);
        }
        public static void LoadValues()
       {
          string[] _cValues = ConfigurationManager.AppSettings["Meter.Values"].ToString().Split(',');
          foreach(string val in _cValues)
          {
            string[] _param = val.Split(':');
            meterList.Add(Convert.ToInt32(_param[0]), Convert.ToInt32(_param[1]);
          }
       }
    }
