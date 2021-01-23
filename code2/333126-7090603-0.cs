    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Mailing Mailing { get; set; }
        public Physical Physical { get; set; }
    }
    class Mailing
    {
        public int MailingId { get; set; }
        public string Name { get; set; }
    }
    class Physical
    {
        public int PhysicalId { get; set; }
        public string Name { get; set; }
    }
    public void TestSOQuestion()
    {
        string sql = @"select 1 as Id, 'hi' as Name, 1 as MailingId, 
           'bob' as Name, 2 as PhysicalId, 'bill' as Name";
        var item = connection.Query<Company, Mailing, Physical, Company>(sql,
                    (org, mail, phy) =>
                    {
                        org.Mailing = mail;
                        org.Physical = phy;
                        return org;
                    },
                        splitOn: "MailingId,PhysicalId").First();
        item.Mailing.Name.IsEqualTo("bob");
        item.Physical.Name.IsEqualTo("bill");
    }
