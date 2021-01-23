    [Test]
    public void Attack_TargetWith3Damage_CausesAttackerToDeal3DamageToTarget()
    {
        var attacker = A.Fake<Creature>();
        A.CallTo(attacker).CallsBaseMethod(); //Otherwise it seems all calls are no-ops.
        attacker.Stats.Damage = 3;
            
        var target = A.Fake<ICreature>();
        attacker.Attack(target);
        A.CallTo(() => attacker.DealDamage(target, 3)).MustHaveHappened();
    }
