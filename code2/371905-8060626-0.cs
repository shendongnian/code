    [Test]
    public void ConcurrentEditsShouldThrowExceptionInsteadOfOverwritingChanges()
    {
        int id;
        // Arrange
        using (var session = _sessionFactory.OpenSession())
        {
            var bob = new Employee
            {
                Status = EmploymentStatus.Hired,
                PhoneNumber = "(234) 567-8901"
            };
            session.Save(bob);
            session.Flush();
            id = bob.Id;
        }
        try
        {
            // Act
            using (var bobSession = _sessionFactory.OpenSession())
            {
                // Bob and his manager both fetch the same version of Bob's data...
                var bob1 = bobSession.Get<Employee>(id);
                using (var managerSession = _sessionFactory.OpenSession())
                {
                    var bob2 = managerSession.Get<Employee>(id);
                    // The manager saves his changes first, firing Bob...
                    bob2.Status = EmploymentStatus.Fired;
                    managerSession.Update(bob2);
                    managerSession.Flush();
                }
                Assert.Throws<Exception>(() =>
                {
                    // Bob then saves his changes, updating his phone number.
                    bob1.PhoneNumber = "(987) 654-3210";
                    bobSession.Update(bob1);
                    // At this point, NHibernate will see the Version column and realize that
                    // Bob is updating an old copy of the data.  Instead of allowing Bob to
                    // inadvertently overwrite his manager's changes and unintentionally un-fire
                    // himself, NHibernate will throw an exception.
                    bobSession.Flush();
                });
            }
            // Assert
            using (var session = _sessionFactory.OpenSession())
            {
                var bob = session.Get<Employee>(id);
                // Without NHibernate's optimistic concurrency checks, Bob's status would have
                // been set back to "Hired".  Instead, we should expect to still see the "Fired"
                // status that his manager set.
                Assert.That(bob.Status, Is.EqualTo(EmploymentStatus.Fired));
            }
        }
        finally
        {
            // Cleanup
            using (var session = _sessionFactory.OpenSession())
            {
                var bob = session.Get<Employee>(id);
                session.Delete(bob);
                session.Flush();
            }
        }
    }
