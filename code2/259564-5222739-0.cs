    void TableIsJob(Job j, BindingFlags b) {
       HandleTable("Job", j.JobID, typeof(Job).GetProperties(b),
                   p=>p.GetGetMethod().Invoke(j, null));
    }
    
    
    void TableIsEstimation(Estimation e, BindingFlags b) {
       HandleTable("Estimation", e.EstimationID, typeof(Estimation).GetProperties(b),
           p => p.GetGetMethod().Invoke(e, null));
    }
    
    void HandleTable(string nm, int ID, PropertyInfo [] props, Func<PropertyInf, Object> i) {
           string desc = string.Join(Environment.NewLine, props.Select(p=>{
                           return string.Format("{0}: {1}", p.Name,
                                        StripDate(i(p)));
                   }).ToArray());
           Audit(JobID, desc, string.Format("New {0} created", nm),
                 SourceID, "", id);
    }
