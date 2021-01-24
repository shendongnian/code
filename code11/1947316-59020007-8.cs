    public class StockServices: IStockServices {    
        private readonly HttpClient client;
    
        public StockServices(HttpClient client) {
            this.client = client;
        }
    
        public async Task<IEnumerable<RoundTableERPDal.Models.Stock>> GetAspNetDocsIssues() {
            using(var response = await client.GetAsync("/Stock/All")) {
    
                response.EnsureSuccessStatusCode();
        
                var result = await response.Content.ReadAsStringAsync();
        
                return JsonConvert.DeserializeObject<IEnumerable<RoundTableERPDal.Models.Stock>>(result);
            }
        }
    }
