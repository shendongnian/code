C#
public async Task<Response> GetAllVasInformationAsync(IProgress<string> progress)
{
  var userDetails = UpdateWhenComplete(GetUserDetailsAsync(), "user details");
  var getWageInfo = UpdateWhenComplete(GetUserWageInfoAsync(), "wage information");
  var getSalaryInfo = UpdateWhenComplete(GetSalaryInfoAsync(), "salary information");
  await Task.WhenAll(userDetails, getWageInfo, getSalaryInfo);
  return new Response
  {
    IsuserDetailsSucceeded = await userDetails,
    IsgetWageInfoSucceeded = await getWageInfo,
    IsgetSalaryInfoSucceeded = await getSalaryInfo,
  };
  async Task<T> UpdateWhenComplete<T>(Task<T> task, string taskName)
  {
    try { return await task; }
    finally { progress?.Report($"Completed {taskName}"); }
  }
}
If you also need a count, you can either use `IProgress<(int, string)>` or change how the report progress string is built to include the count.
