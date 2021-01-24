    [HttpPost]
    public async Task<ActionResult> InviteUser([Bind(Include = "EmailId")] UserLogin userLogin) {
        if (ModelState.IsValid) {
            string result = await AzureADUtil.InviteUser(userLogin.EmailId);
        }
        return View();
    }
