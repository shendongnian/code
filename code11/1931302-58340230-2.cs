    //...
    public class CustomerDemandController : ControllerBase
    {
        private const string GetByIdOperation = "GetCustomerDemandById"; //<-- Unique
    
        [Get("{id}", Name = GetByIdOperation)]
        public async Task<ActionResult<CustomerDemandResponse>> GetAsync([FromRoute] string id)
                => await this.GetAsync(() => Service.GetByIdAsync(id),
                                       ConversionHelper.Convert);
    
        //...
