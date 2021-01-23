    if (!string.IsNullOrWhiteSpace(jobNumber)) return _context.Jobs.Where(j => j.JobNumber.Contains(jobNumber));
    if (!string.IsNullOrWhiteSpace(jobName)) return _context.Jobs.Where(j => j.JobName.Contains(jobName));
    if (!string.IsNullOrWhiteSpace(projectDirectorName)) return _context.Jobs.Where(j => j.ProjectDirectorFullName.Contains(projectDirectorName));
    if (!string.IsNullOrWhiteSpace(groupName)) return _context.Jobs.Where(j => j.GroupName.Contains(groupName));
    else throw new ArgumentException ("No arguments specified");
