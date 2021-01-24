        public class MyTelemetryInitializer : ITelemetryInitializer
        {
            public void Initialize(ITelemetry telemetry)
            {
                if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
                {
                    //set custom role name here
                    telemetry.Context.Cloud.RoleName = "RoleName";
                }
            }
        }
