     var policyMapping = new PolicyMapping
            {
                Id = new Guid("b27fb632-330b-46be-a649-2e2463d58626"),
                PolicyAId = new Guid("a4f1cf6f-034d-4727-ab8f-49e95b2c9d23"),
                PolicyBId = new Guid("a4f1cf6f-034d-4727-ab8f-49e95b2c9d23"),
                BankId = new Guid("98ed2bae-631b-490c-8ddf-3e02232d4231")
            };
            dbContext.PolicyMapping.Attach(policyMapping);
            dbContext.Entry(policyMapping).Property("PolicyAId").IsModified = true;
            dbContext.Entry(policyMapping).Property("PolicyBId").IsModified = true;
            dbContext.Entry(policyMapping).Property("BankId").IsModified = true;
            dbContext.SaveChanges();
