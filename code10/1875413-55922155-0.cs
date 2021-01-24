    private List<AliveDTO> getDeads()
    {
        List<AliveDTO> DTOs = APIRequests.Instance.GetAliveDTOs();
        return DTOs.Where(x =>
            x.watchWindowStartTime.CompareTo(DateTime.Now) < 0 ||
            x.watchWindowEndTime.CompareTo(DateTime.Now) > 0 && 
            DateTime.Now > x.timeReceived.AddMinutes((double)x.NextAliveWithinMinutes)).ToList();
    }
