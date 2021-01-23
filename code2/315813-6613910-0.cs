            MembershipUser mu = Membership.GetUser();
            if (mu.PasswordQuestion == null || mu.PasswordQuestion.Length < 3)
            {
                Response.Redirect("~/Account/ChangePasswordQuestion.aspx");
            }
