    [HtttPost]
    public ActionResult UpdateInformation(UserModel user, EditUserModel editUserModel) {
        if (ModelState.IsValid) {
             // copy the inner model to the outer model, workaround here:
             editUserModel.User = user
             // do whatever you want with editUserModel, it has all the needed information
        }
    }
