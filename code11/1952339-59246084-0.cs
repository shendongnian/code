    public void MonsterDeath(GameObject monster)
    {
        MonsterComp monsterComp = monster.GetComponent<MonsterComp>();
        if (monsterComp != null && monsterComp.IsAlive)
        {
            monsterComp.IsAlive = false;
            EnemiesRemaining -= 1;
            Player.GetComponent<PlayerStats>().PlayerGetsKill();
            UIManager.SetEnemiesText(EnemiesRemaining + "");
            if (EnemiesRemaining <= 0)
            {
                WaveOver();
            }
        }
    }
