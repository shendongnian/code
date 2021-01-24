    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EductionAPI.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    
    namespace EductionAPI.Controllers
    {
        [Route("api/[controller]/{text}")]
        [ApiController]
        public class MoneyEductionController : ControllerBase
        {
            private IConfiguration _configuration;
            public MoneyEductionController(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public MoneyEduced EduceFromText(string text)
            {
                var retVal = new MoneyEduced();
                var eductionService = new EductionService(_configuration);
                string matched_text = eductionService.GetMatchedCurrency(text);
    
                retVal.CurrencyValue = matched_text;
                retVal.ConvertCurrencyToInt ();
                retVal.CalculateTax();
                return retVal;
            }
        }
    }
