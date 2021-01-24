    return process.Join(pendingProcess,
        p => new { p.ProcessId, p.GroupId }
        pp => new { pp.ProcessId, pp.GroupId }
        (p, pp) => new Process
        {
            ProcessId = p.ProcessId,
            GroupId = p.GroupId,
            Text = p.Text,
        }).ToList();
