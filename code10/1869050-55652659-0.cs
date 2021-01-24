    public IActionResult Modify(Int64 id)
            {
                UserModel users = _user.GetAll(id);
                ViewBag.businessUnit = new SelectList(_businessUnit.GetAll("A").Select(x => new
                {
                    Value = x.BU_Code,
                    Text = x.BU_Name
                }), "Value", "Text", users.BU_Code);
    
                return View(users);
            }
