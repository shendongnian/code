    public class BPAlerts
        {
            public List<BPAlert> AllAlerts { get; set; }
            public List<BPAlert> OverviewAlerts {
                get
                    {
                        return null == this.AllAlerts ? null : this.AllAlerts.Where (do you filtering and maybe sorting here ) ; 
                    } 
                }
        }
            public List<BPAlert> AllAlertsSorted{
                get
                    {
                        return null == this.AllAlerts ? null : this.AllAlerts.Sort(do you filtering and maybe sorting here ) ; 
                    } 
                }
        }
