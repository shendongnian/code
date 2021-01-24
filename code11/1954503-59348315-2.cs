           var userdata = context.studs.Where(x => x.username.Equals(studs.username)).FirstOrDefault();
            if (userdata != null)
            {
                if (userdata.Password == userdata.Password) //success
                {
                    HttpContext.Session.SetInt32("id", userdata.id);
                    if (userdata.usertype == "admin")
                        return RedirectToAction("Index", "LogReg");
                    else
                        return RedirectToAction("Clientview", "LogReg");
                }
                else
                {
                    ViewBag.Message = "Invalid Password!";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Invalid Email!";
                return View();
            }
