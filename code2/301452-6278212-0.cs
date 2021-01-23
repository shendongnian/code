    public class ScheduleTrigger : BaseTrigger
        {
            Guid name = Guid.NewGuid();
            static Dictionary<Guid, ScheduleTrigger> triggers = new Dictionary<Guid, ScheduleTrigger>();
            public static Dictionary<Guid, ScheduleTrigger> Triggers
            {
                get
                {
                    return triggers;
                }
            }
            public void Init(Trigger triggerParam)
            {
               ....
               JobDetail jobDetail = new JobDetail(name.ToString(), Type.GetType(schedTrig.JobType.JobClassName));
               Triggers.Add(name, this);
            }
            public void Dispose()
            {
                if (Triggers.ContainsKey(name))
                {
                    triggers.Remove(name);
                }
                base.Dispose();
            }
            internal void RaiseEvent()
            {
                base.OnInputTrigged(string.Empty);
            }
       }
