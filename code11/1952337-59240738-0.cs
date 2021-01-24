    public void MonsterDeath(GameObject monster)
    {
        if(DeadMonsters.Contains(monster))
        {
            return;
        }
        DeadMonsters.Add(monster);
        EnemiesRemaining -= 1;
        Player.GetComponent<PlayerStats>().PlayerGetsKill();
        UIManager.SetEnemiesText(EnemiesRemaining + "");
        if (EnemiesRemaining <= 0)
        {
            WaveOver();
        }
    }
