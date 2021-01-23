    [Test]
    public void TestExcludingQBE()
    {
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				Componentizable master = GetMaster("hibernate", null, "ope%");
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike()
					.ExcludeProperty("Component.SubComponent");
				crit.Add(ex);
				IList result = crit.List();
				Assert.IsNotNull(result);
				Assert.AreEqual(3, result.Count);
				master = GetMaster("hibernate", "ORM tool", "fake stuff");
				crit = s.CreateCriteria(typeof(Componentizable));
				ex = Example.Create(master).EnableLike()
					.ExcludeProperty("Component.SubComponent.SubName1");
				crit.Add(ex);
				result = crit.List();
				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
				t.Commit();
			}
		}
