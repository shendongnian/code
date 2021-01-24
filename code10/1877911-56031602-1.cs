    public abstract class Item {
        public virtual bool IsEquivalent(Item i2) {
            return true;
        }
    }
    
    public class WeaponItem : Item {
        public int strength;
    
        public override bool IsEquivalent(Item i2) {
            var ans = base.IsEquivalent(i2);
            if (i2 is WeaponItem w2)
                ans = ans && strength == w2.strength;
            return ans;
        }
    }
