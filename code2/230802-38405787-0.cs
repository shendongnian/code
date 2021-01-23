                dynamic psd = DBNull.Value;
                if (schedule.pushScheduleDate > DateTime.MinValue)
                {
                    psd = schedule.pushScheduleDate;
                }
                sql.DBController.RunGeneralStoredProcedureNonQuery("SchedulePush",
                         new string[] { "@PushScheduleDate"},
                         new object[] { psd }, 10, "PushCenter");
