    [Test]
    public void HitShouldBeCalledByAttack()
    {
        // Arrange all our data for testing
        const string target = "the evildoers";
        var mock = new Mock<IWeapon>();
        mock.Setup(w => w.Hit(target))
            .AtMostOnce();
        IWeapon mockWeapon = mock.Object;
        var warrior1 = new Samurai(mockWeapon);
        // Act on our code under test
        warrior1.Attack(target);
        // Assert Hit was called
        mock.Verify(w => w.Hit(target));
    }
