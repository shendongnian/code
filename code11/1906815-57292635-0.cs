C#
public async Task<List<JobApplication>> GetApplications()
{
  var canInfo = await GetCandidates();
  var jobApplication = await GlobalVar.firebaseClient
          .Child("JobApplication")
          .OnceAsync<JobApplication>();
  return jobApplication.Select(item => new JobApplication
  {
    CandidateID = item.Object.CandidateID,
    ApplicationDate = item.Object.ApplicationDate,
    ApplicationTime = item.Object.ApplicationTime,
    CandidateName = canInfo.Find(a => a.CandidateId == item.Object.CandidateID).Name + " " + canInfo.Find(a => a.CandidateId == item.Object.CandidateID).LastName,
    NewCanID = item.Object.CandidateID.Substring(1),
    ImageURL = GetFile(item.Object.CandidateID.Substring(1) + "-One.jpg") // error
  }).ToList();
}
You need to use `await` on the `Task<string>` returned from `GetFile`, and this requires the lambda passed to `Select` to be `async`.
C#
public async Task<List<JobApplication>> GetApplications()
{
  var canInfo = await GetCandidates();
  var jobApplication = await GlobalVar.firebaseClient
          .Child("JobApplication")
          .OnceAsync<JobApplication>();
  return jobApplication.Select(async item => new JobApplication
  {
    CandidateID = item.Object.CandidateID,
    ApplicationDate = item.Object.ApplicationDate,
    ApplicationTime = item.Object.ApplicationTime,
    CandidateName = canInfo.Find(a => a.CandidateId == item.Object.CandidateID).Name + " " + canInfo.Find(a => a.CandidateId == item.Object.CandidateID).LastName,
    NewCanID = item.Object.CandidateID.Substring(1),
    ImageURL = await GetFile(item.Object.CandidateID.Substring(1) + "-One.jpg")
  }).ToList();
  // error: the code is now trying to return Task<List<Task<JobApplication>>>
}
Now, you have a sequence of *tasks* returned from `Select`. You can either (asynchronously) wait for them to complete one at a time:
C#
public async Task<List<JobApplication>> GetApplications()
{
  var canInfo = await GetCandidates();
  var jobApplication = await GlobalVar.firebaseClient
          .Child("JobApplication")
          .OnceAsync<JobApplication>();
  var result = new List<JobApplication>();
  foreach (var item in jobApplication)
  {
    result.Add(new JobApplication
    {
      CandidateID = item.Object.CandidateID,
      ApplicationDate = item.Object.ApplicationDate,
      ApplicationTime = item.Object.ApplicationTime,
      CandidateName = canInfo.Find(a => a.CandidateId == item.Object.CandidateID).Name + " " + canInfo.Find(a => a.CandidateId == item.Object.CandidateID).LastName,
      NewCanID = item.Object.CandidateID.Substring(1),
      ImageURL = await GetFile(item.Object.CandidateID.Substring(1) + "-One.jpg")
    });
  }
  return result;
}
Or, you can start them all simultaneously and then wait for them all to complete:
C#
public async Task<List<JobApplication>> GetApplications()
{
  var canInfo = await GetCandidates();
  var jobApplication = await GlobalVar.firebaseClient
          .Child("JobApplication")
          .OnceAsync<JobApplication>();
  var tasks = jobApplication.Select(async item => new JobApplication
  {
    CandidateID = item.Object.CandidateID,
    ApplicationDate = item.Object.ApplicationDate,
    ApplicationTime = item.Object.ApplicationTime,
    CandidateName = canInfo.Find(a => a.CandidateId == item.Object.CandidateID).Name + " " + canInfo.Find(a => a.CandidateId == item.Object.CandidateID).LastName,
    NewCanID = item.Object.CandidateID.Substring(1),
    ImageURL = await GetFile(item.Object.CandidateID.Substring(1) + "-One.jpg")
  }).ToList();
  var result = await Task.WhenAll(tasks);
  return result.ToList();
}
