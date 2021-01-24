    return process
        .Where(p => pendingProcess.Any(pp=> pp.GroupId == p.GroupId && pp.Precessid == p.PreocessId))
        .Select(p=> new Process
                {
                    ProcessId = p.ProcessId,
                    GroupId = p.GroupId,
                    Text = p.Text,
                }).ToList();
