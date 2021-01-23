    var ct = new CronTrigger();
    ct.CronExpression = new CronExpression(
        string.Format("0 {0} {1} ? * {2} *", 
        minuteOfHour, hourOfDay, daysList));
    ct = new WeeklyTriggerWrapper(ct, 2);
    public class WeeklyTriggerWrapper : CronTrigger
    {
        public CronTrigger Trigger
        {
            get;
            private set;
        }
        public int WeekInterval
        {
            get;
            private set;
        }
        public DateTime? LastFireDateTime
        {
            get;
            private set;
        }
        public WeeklyTriggerWrapper(CronTrigger trigger, int weekInterval)
        {
            Trigger = trigger;
            WeekInterval = weekInterval;
        }
        public override DateTime? ComputeFirstFireTimeUtc(ICalendar cal)
        {
            return Trigger.ComputeFirstFireTimeUtc(cal);
        }
        public override DateTime? GetFireTimeAfter(DateTime? afterTimeUtc)
        {
            var result = Trigger.GetFireTimeAfter(afterTimeUtc);
            if (result.HasValue)
            {
                DateTime reference = StartTimeUtc;
                if (LastFireDateTime.HasValue && LastFireDateTime.Value > reference)
                    reference = LastFireDateTime.Value;
                reference = reference.AddDays(7 * WeekInterval);
                while (result.HasValue && result.Value < reference)
                    result = Trigger.GetFireTimeAfter(result.Value);
            }
            LastFireDateTime = result;
            return result;
        }
        // TODO: handle events...
    }
