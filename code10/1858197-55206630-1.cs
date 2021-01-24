    [Test]
    public void WhenClaimTypeIsMissingAndAvoidExceptions_FindFirstValue_Returns_Null()
    {
        var principal = new ClaimsPrincipal();
    
        var value = principal.FindFirstValue("claim type value");
    
        Assert.IsNull(value);
    }
    
    [Test]
    public void WhenClaimTypeIsMissingAndThrowExceptions_FindFirstValue_ThrowsException()
    {
        var principal = new ClaimsPrincipal();
    
        var claimType = "claim type value";
    
        Assert.Throws(Is.TypeOf<InvalidOperationException>()
                        .And.Message.EqualTo($"The supplied principal does not contain a claim of type {claimType}")
                    , () => principal.FindFirstValue(claimType, throwIfNotFound: true));
    }
    [Test]
    public void WhenClaimTypeIsFound_FindFirstValue_ReturnsTheValue()
    {
        var principal = new ClaimsPrincipal();
        principal.AddIdentity(new ClaimsIdentity(new List<Claim> {new Claim("type", "1234")}));
        var value = principal.FindFirstValue("type");
        Assert.AreEqual(value,"1234");
     }
