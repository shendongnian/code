    public IEnumerable<Job> GetJobs(string jobNumber, string jobName, string projectDirectorName, string projectManagerName, string groupName) {
            return this._context.Jobs.Where(
                j => (j.JobNumber.Contains(jobNumber) && jobNumber!="")  ||
                     (j.JobName.Contains(jobName) && jobName != "") ||
                     (j.ProjectDirectorFullName.Contains(projectDirectorName) 
                          && projectDirectorName != "") ||
                     (j.GroupName.Contains(groupName) && groupName!=""));
        }
