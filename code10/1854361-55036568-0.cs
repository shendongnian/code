                      var props = new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {
                                "UserName", "AA"
                            }
                        });
                        var ticket = new AuthenticationTicket(identity, props);
                        context.Validated(ticket);
