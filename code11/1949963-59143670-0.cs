c#
public void TakeDamage (float amount){
        health = health - (amount);
        TotalCubesHit += 1;   // <-- Move that outside of the if statement
        if (health <= 0f) {
            
            Die(); 
        }
    }
