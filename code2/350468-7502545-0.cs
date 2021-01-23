        protected void Application_EndRequest(object sender, EventArgs e) {
            if (Context.Response.StatusCode == 401 || Context.Response.StatusCode == 403) {
            // this is important, because the 401 is not an error by default!!!
                throw new HttpException(401, "You are not authorised");
            }
        }
