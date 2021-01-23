    using (MyContextClass ctx = new MyContextClass) {
        if (ctx.SingleOrDefault(f => f.Username == txtUsername.Text && f.Password == txtPassword.Text) != null) {
            // The user got it right.
        }
    }
