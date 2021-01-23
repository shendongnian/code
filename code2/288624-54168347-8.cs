    public class DeviceDriverModel : Base
        {
     public class DeviceDriverSaveUpdate
            {
                public string DeviceVehicleId { get; set; }
                public string DeviceId { get; set; }
                public string DriverId { get; set; }
                public string PhoneNo { get; set; }
                public bool IsActive { get; set; }
                public string UserId { get; set; }
                public string HostIP { get; set; }
            }
    
    
            public Task<long> DeviceDriver_SaveUpdate(DeviceDriverSaveUpdate obj)
            {
    
                return DatabaseHub.ExecuteAsync(
                        storedProcedureName: "[dbo].[sp_SaveUpdate_DeviceDriver]", model: obj, dbName: AMSDB);//Database name defined in Base Class.
            }
    }
