                      var props = new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {
                                "UserName", "AA"
                            },
                            {
                                 "UserId" , "1"
                            }
                        });
                        var ticket = new AuthenticationTicket(identity, props);
                        context.Validated(ticket);
