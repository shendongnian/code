c#
public class UpdateAddressDTO
{
        [Required]
        public string email { get; set; }
        [Required]
        public string address_1 { get; set; }
        [Required]
        public string address_2 { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string region { get; set; }
        [Required]
        public string postal_code { get; set; }
        [Required]
        public string country { get; set; }
}
[Route("address/{shipping_region_id}/update")]
public async Task<IActionResult> UpdateAddress([FromUri]int shipping_region_id, [FromBody]UpdateAddressDTO model)
{
     
}
