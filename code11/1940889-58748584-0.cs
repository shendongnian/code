    public class AzureSearchIndexController : Controller {
    
        //...
    
       [HttpGet]
       public async Task<IActionResult> StartIndex() {
    
            //...
    
            await _azureSearchDataSyncService.StartIndexingAsync(_siteId, _siteName);
    
            //...
        }
    }
