       class Program
        {
           
            static void Main(string[] args)
            {
                int CURRENT_TIMESTAMP = 123;
                List<CONFIGURATION_LOG> logs = new List<CONFIGURATION_LOG>();
                var results = logs.Where(x => (x.APP_ID == 173) && (x.ROW_LST_UPD_TS >= CURRENT_TIMESTAMP - 7))
                    .OrderByDescending(x => x.ROW_LST_UPD_TS)
                    .GroupBy(x => x.SETTING_NAME)
                    .Select(x => x.FirstOrDefault())
                    .Select(x => new
                    {
                        setting_name = x.SETTING_NAME,
                        setting_value = x.SETTING_VALUE,
                        row_lst_upd_ts = x.ROW_LST_UPD_TS,
                        machine_name = x.MACHINE_NAME,
                        row_lst_upd_uid = x.ROW_LST_UPD_UID
                    }).ToList();
            }
        }
        public class EVENT_MGT
        {
            CONFIGURATION_LOG CONFIGURATION_LOG { get; set; } 
        }
        public class CONFIGURATION_LOG
        {
            public string SETTING_NAME { get; set; }
            public string SETTING_VALUE { get; set; }
            public int ROW_LST_UPD_TS { get; set; }
            public string MACHINE_NAME { get; set; }
            public string ROW_LST_UPD_UID { get; set; }
            public int APP_ID { get; set; }
        }
     
