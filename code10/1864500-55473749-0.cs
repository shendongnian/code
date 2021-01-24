    else
                {
                    //Session["UserID"] = user.Id;
                    ////int userID = user.Id;
                    //if (user.BIO == null )//|| user.Preffered == null || user.Sex == null || user.BIO == null)
                    //{
                    //    return RedirectToAction("index", "Chat");
                    //}
                    //return RedirectToAction("Index", "Home");
                **FormsAuthentication.SetAuthCookie(username, false);**
                    return Redirect("/chat");
                }
