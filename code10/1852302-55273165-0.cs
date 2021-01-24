        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = httpContext.Request.Cookies[cookieName];
            _authenticated = base.AuthorizeCore(httpContext);
            string authToken = httpContext.Request.Headers["Auth-Token"];
            if (_authenticated)
            {
                if (authCookie == null)
                {
                    if (string.IsNullOrEmpty(InRoles))
                    {
                        _authorized = true;
                        return _authorized;
                    }
                    if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
                    {
                        string NTID = httpContext.User.Identity.Name.Split('\\')[1];
                        var roles = InRoles.Split(',');
                        using (Models.UserAuthEntities userAuthEntities = new Models.UserAuthEntities())
                        {
                            try
                            {
                                ObjectResult<Models.Validate_User_Login_Result> userResults = userAuthEntities.Validate_User_Login(NTID);
                                var user = userResults.FirstOrDefault(all => all.NTID == NTID);
                                if (user == null)
                                {
                                    _authorized = false;
                                    return _authorized;
                                }
                                else
                                {
                                    if (roles.Contains(user.Role))
                                    {
                                        _authorized = true;
                                        return _authorized;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                _authorized = false;
                                return _authorized;
                            }
                        }
                    }
                    else
                    {
                        _authorized = false;
                        return _authorized;
                    }
                }
            }
            _authorized = false;
            return _authorized;
        }
