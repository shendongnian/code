    public struct WMIProcessProperties
    {
        public string Owner;
        public int ID;
    }
    public static async Task<Dictionary<Process, WMIProcessProperties>> GetWMIProperties(this IEnumerable<Process> processes)
    {
        Dictionary<Process, WMIProcessProperties> result = new Dictionary<Process, WMIProcessProperties>();
        if (processes == null || processes.Count() == 0) { return result; }
        string selectQuery = "SELECT Handle, ProcessID FROM Win32_Process";
        selectQuery += processes.Count() <= 10 ? string.Format(" WHERE ProcessID = {0}", string.Join(" OR ProcessID = ", processes.Select(p => p.Id))) : string.Empty;
        using (CimSession session = await Task.Run(() => CimSession.Create(processes.ElementAt(0).MachineName)))
        {
            List<CimInstance> instances = await Task.Run(() => session.QueryInstances(@"root\cimv2", "WQL", selectQuery).ToList());
            List<Task<WMIProcessProperties>> tasks = new List<Task<WMIProcessProperties>>();
            for (int i = 0; i < instances.Count; i++)
            {
                CimInstance currentInstance = instances[i];
                tasks.Add(Task.Run(() =>
                {
                    int id = Convert.ToInt32(currentInstance.CimInstanceProperties["ProcessID"].Value);
                    string owner;
                    using (CimMethodResult getOwnerResult = session.InvokeMethod(currentInstance, "GetOwner", null))
                    {
                         owner = getOwnerResult.OutParameters["User"]?.Value?.ToString();
                    }
                    currentInstance.Dispose();
                    return new WMIProcessProperties { Owner = owner, ID = id };
                }));
            }
            WMIProcessProperties[] wmiProcessProperties = await Task.WhenAll(tasks).ConfigureAwait(false);
            for (int i = 0; i < wmiProcessProperties.Length; i++)
            {
                result.Add(processes.Single(p => p.Id == wmiProcessProperties[i].ID), wmiProcessProperties[i]);
            }
        }
        return result;
    }
