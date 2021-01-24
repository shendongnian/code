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
                    .GroupBy(x => new { name = x.SETTING_NAME, row_ts = x.ROW_LST_UPD_TS })
                    .Select(x => new
                    {
                        setting_name = x.Key.name,
                        setting_value = string.Join(",", x.Select(y => y.SETTING_VALUE)),
                        row_lst_upd_ts = x.Key.row_ts,
                        machine_name = string.Join(",", x.Select(y => y.MACHINE_NAME)),
                        row_lst_upd_uid = string.Join(",", x.Select(y => y.ROW_LST_UPD_UID))
                    }).ToList();
            }
        }
        public class EVENT_MGT
        {
            public CONFIGURATION_LOG CONFIGURATION_LOG { get; set; } 
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
     
