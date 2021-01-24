public ActionResult DeleteUser()
{
            var c = User.Identity.GetUserId(); // get the user id
            
            UserManager.Delete(UserManager.FindById(c)); // remove the user
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie); // sign out
            /*return RedirectToAction("Login"); // goes to login page*/
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    ```
