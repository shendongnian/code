    public static class Test
    {
        private static readonly BridgeApiClient bridgeApiClient = new BridgeApiClient("http://localhost/Service.svc", "username", "password");
        public static bool TestMethod(string trip)
        {
            TripRequest tr = new TripRequest();
            tr.TripNumber = trip;
            var response = bridgeApiClient.GetTrip(tr);
            return true;
        }
    }
