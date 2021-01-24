private void SetUnverifiedCandidates()
{
   var unverified = dbCtxt.Candidates
      .GroupJoin(
         dbCtxt.Results,
         candidate => candidate.CandidateNo,
         result => result.CandidateNo
         (candidate, results) => new { candidate, results }
      )
      .SelectMany(
         joined => joined.results.DefaultIfEmpty(),
         (joined, result) => new { joined.candidate, result }
      )
      .Where(joined => joined.result == null)
      .Select(joined => joined.candidate);
      foreach (var candidate in unverified)
      {
         candidate.Status = "Unverified";
      }
      dbCtxt.SaveChanges();
}
private void SetVerifiedCandidates()
{
   var verified = dbCtxt.Candidates
      .Join(
         dbCtxt.Results,
         candidate => candidate.CandidateNo,
         result => result.CandidateNo
         (candidate, result) => candidate
      );
   foreach (var candidate in verified)
   {
      candidate.Status = "Verified";
   }
   dbCtxt.SaveChanges();
}
