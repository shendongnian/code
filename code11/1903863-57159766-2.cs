    [RoutePrefix("api/bids")]
    public class BidsController : ApiController
    {
        [HttpGet, Route("{dateTime:DateTime?}")]
        public async Task<IHttpActionResult> GetBids(DateTime? dateTime = null)
        {
            var correctDate = (dateTime != null) && (dateTime.Value >= DateTime.Now.Date);
            DateTime date = correctDate ? dateTime.Value : DateTime.Now.Date;
            try
            {
                return Ok(date);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                return BadRequest(errorMessage);
            }
        }
    }
