    [ApiController]
    [Route("api/Claim/{claimId}/Detail/[action]/")]
    public class ClaimDetailController
    {
        [FromRoute(Name = "claimId")] 
        public int Id { get; set; }
        public ClaimDetailController(IClaimDetailService claimDetailService)
        {
bla bla
        }
        [HttpPost]
        public async Task<BaseResponse> ClaimDetailInfoPolicy(ClaimDetailKeyModel model)
        {
            return `codes with Id`
        }
    }
