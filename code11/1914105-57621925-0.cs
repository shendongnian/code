C#
[HttpPost("accounts/create", Name = "AdminAccountCreate")]
public async Task<IActionResult> Create([FromServices] IGenPasswordHash genPassHash, RegisterModel regModel)
{
    string passwordHash = genPassHash.GenerateHash(regModel.Password);
    await db.AdministratorUsers.AddAsync(new AdministratorUser
        {
            Login = regModel.Login,
            PasswordHash = passwordHash,
            Tier = regModel.Tier
        });
    // Add this
    db.SaveChanges();
    return RedirectToAction("Accounts");
}
