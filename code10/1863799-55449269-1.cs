    class DamageOverTimeDebuff : ScriptableObject
    {
     int damagePerTick = 1;
    
     OnTick(PlayerObject afflictedPlayer)
     {
      afflictedPlayer.TakeDamage(1);
     }
    }
