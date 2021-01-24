    public class EnemyCombatController : MonoBehaviour
    {
    public PlayerCombatSystem constructorPlayerCombatSystem ;
    
    //your code
    //...
    
    //Damage has changed in the other script (PlayerCombatSystem)
   
    float gotDamage = shotterDamage * (100 / (100 + enemy.constructorPlayerCombatSystem.Damage);
    }
