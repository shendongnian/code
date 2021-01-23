    ISessionFactory factory = GetSessionFactory();
    ISession session = factory.OpenSession();
    Message m = new Message()
                    {
                        Body = "Please note 2",
                        Subject = "Secret 2",
                        From = new BasicUser(){Id = 2},
                        SentAt = DateTime.Now,
                    };
    var basicUser1 = new BasicUser(){Id = 1};
    session.Save(basicUser1);
    m.To.Add(basicUser1);
    var basicUser3 = new BasicUser(){Id = 3};
    session.Save(basicUser3);
    m.To.Add(basicUser3);
    session.Save(m);
    session.Flush();
