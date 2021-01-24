    public class Enemy : Monobehaviour {
        private int health;
        public void applyDamage(int amount) {
            health-=amount;
        }
    };
