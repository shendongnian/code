    public class FilterParams
    {
        // ...
        public IEnumerable<string> GetValues()
        {
            if (MeetingId != null) yield return MeetingId;
            if (ClientId.HasValue) yield return ClientId.Value.ToString();
            // ...
            if (Rating != 0)       yield return Rating.ToString();
            // ...
        }
    }
