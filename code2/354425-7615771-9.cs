    public class AirbrakeNotice
    {
        // Note there is no implementation
    }
    internal class AirbreakNoticeMap
    {
        static AirbreakNoticeMap()
        {
            Map = new Dictionary<AirbreakNotice, SharpBreak.AirbreakNotice>();
        }
        public static Dictionary<AirbreakNotice, SharpBreak.AirbreakNotice> Map { get; }
    }
    public interface IAirbrakeClient
    {
        void Send(AirbrakeNotice notice);
        // ...
    }
    internal class AirbrakeClientWrapper : IAirbrakeClient
    {
        private AirbrakeClient _airbrakeClient;
        public void Send(AirbrakeNotice notice)
        {
            SharpBreak.AirbrakeNotice actualNotice = AirbreakNoticeMap.Map[notice];
            _airbrakeClient.Send(actualNotice);
        }
        // ...
    }
    internal class AirbrakeNoticeBuilderWrapper : IAirbrakeNoticeBuilder
    {
        AirbrakeNoticeBuilder _airbrakeNoticeBuilder;
        public AirbrakeNotice Notice(Exception exception)
        {
            SharpBreak.AirbrakeNotice actualNotice =
                _airbrakeNoticeBuilder.Notice(exception);
            AirbrakeNotice result = new AirbrakeNotice();
            AirbreakNoticeMap.Map[result] = actualNotice;
            return result;
        }
        // ...
    }
