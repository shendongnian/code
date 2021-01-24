    using Bright.Models;
    using Microsoft.AspNetCore.Mvc;
    
    
    namespace Bright.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CreateRepairOrderController : ControllerBase
        {
    
            [HttpPost]
            public CreateRepairOrderResponse Post(CreateRepairOrderRequest createRequest)
            {
                this.Validate(createRequest);
    
                if (!ModelState.IsValid) 
                {
                 //return BadRequest(ModelState);
                 return new CreateRepairOrderResponse() { AckMessage = "Creation Failed: Missing required field", RetCode = "1" };
                }
            }
    }
