                //To prepare call backs pending 
                var phoneCallTypeId = (int) RecordEnums.TaskType.PhoneCall;
                var exclude1 = GetExclude(hideWithCallBacksPending, companyId, phoneCallTypeId);
                //To prepare appointments backs pending       
                var appointmentTypeId = (int) RecordEnums.TaskType.Appointment;
                var exclude2 = GetExclude(hideWithCallBacksPending, companyId, appointmentTypeId);
