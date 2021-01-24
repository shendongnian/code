C#
public class SECScraper
{
  public async Task DownloadAsync()
  {
    _numDownloaded = 0;
    _interval = _financeContext.Companies.Count() / 100;
    var tasks = _financeContext.Companies.Select(company => RetrieveSECDataAsync(company.CIK)).ToList();
    await Task.WhenAll(tasks);
  }
  private async Task RetrieveSECDataAsync(int cik)
  {
    var url = "https://www.sec.gov/cgi-bin/browse-edgar?action=getcompany&CIK=" + cik +
        "&type=10-q&dateb=&owner=include&count=100";
    var srBody = await ReadHTMLAsync(url);
    var srPage = new SearchResultsPage(srBody);
    var reportLinks = srPage.GetAllReportLinks();
    foreach (var link in reportLinks)
    {
      url = SEC_HOSTNAME + link;
      var fdBody = await ReadHTMLAsync(url);
      var fdPage = new FilingDetailsPage(fdBody);
      var xbrlLink = fdPage.GetInstanceDocumentLink();
      var xbrlBody = await ReadHTMLAsync(SEC_HOSTNAME + xbrlLink);
      var xbrlDoc = new XBRLDocument(xbrlBody);
      var epsData = xbrlDoc.GetAllEPSData();
    }
    IncrementNumDownloadedAndNotify();
  }
  private async Task<string> ReadHTMLAsync(string url)
  {
    using var response = await _client.GetAsync(url);
    return await response.Content.ReadAsStringAsync();
  }
}
Also, I recommend you use `IProgress<T>` for reporting progress.
