    public void IsHit(int damage, Vector3 hitDirection){
         if (IsDead) return;
         aiHealth -=damage;
         if (aiHealth <= 0) {
             Death();
             return false;
         }
         IsHitWhenNotDead(damage, hitDirection);
    }
    protected virtual void IsHitWhenNotDead(int damage, Vector3 hitDirection){
    }
