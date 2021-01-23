    var Devices = dc.DeviceTypes
        .Select(p=>new 
            {
                 DeviceName = p.DeviceName ,
                 settings = p.DeviceParameters
                     .Select(q=>new
                     {
                         ParamName = p.ParamName,
                         Param1 = q.Param1,
                         Param2 = q.Param2,
                         Param3 = q.Param3
                     })
            });
        
