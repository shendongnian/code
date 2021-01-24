    public class StockServices: IStockServices {
    
        public HttpClient Client { get; }
    
        public StockServices(HttpClient client) {
            Client = client;
        }
    
        public async Task<IEnumerable<RoundTableERPDal.Models.Stock>> GetAspNetDocsIssues() {
            using(var response = await Client.GetAsync("/Stock/All")) {
    
                response.EnsureSuccessStatusCode();
        
                var result = await response.Content.ReadAsStringAsync();
        
                return JsonConvert.DeserializeObject<IEnumerable<RoundTableERPDal.Models.Stock>>(result);
            }
        }
    }
