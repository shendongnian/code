           using (var context = new TestDbContext())
            {
                var a = context.As.Single(x => x.Id == 1);
                var b = context.Bs.Single(x => x.Id == 1);
                Assert.AreEqual(2, b.A_id);
                b.A = a;
                context.SaveChanges();
                Assert.AreEqual(1, b.A_Id);
            }
