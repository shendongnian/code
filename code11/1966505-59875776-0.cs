[Route("/v1.0/patch_user")]
    [HttpPatch]
    public async Task<IActionResult> PatchUserInfo(CustomerChangeViewModel customerChange)
    { ... }
to 
[Route("/v1.0/patch_user")]
    [HttpPatch]
    public async Task<IActionResult> PatchUserInfo([FromBody] CustomerChangeViewModel customerChange)
    { ... }
