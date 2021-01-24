        public class Attacker : MonoBehaviour
        {
            public Weapon weapon;
    
            public void Attack(IDamageGetter target) => target.GetDamage(weapon.damage);
        }
    
        public interface IDamageGetter
        {
           void GetDamage(int Damage);
        }
    
        [CreateAssetMenu(menuName = "Base Weapon")]
        public class Weapon : ScriptableObject
        {
            public int damage = 5;
        }
