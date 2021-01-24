    public class Player
    {
        //Stats of the player
        public int HP { get; set; }
        public int MP { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public void UseItem(Item item) //The parameter is the Item to be used. A potion in my case
        {
            item.Use(this);
        }
    }
    public abstract class Item
    {
        public string Name { get; set;} //Name of the item
        public abstract void Use(Player player);
    }
    public enum BonusType
    {
        HP,
        MP,
        Strength,
        Defence
    }
    public class Potion : Item
    {
        public BonusType BonusType { get; set; }
        public int Amount { get; set; }
        public override void Use(Player player)
        {
            switch (BonusType)
            {
                case BonusType.HP:
                    player.HP += Amount;
                    break;
                case BonusType.MP:
                    player.MP += Amount;
                    break;
                case BonusType.Strength:
                    player.Strength += Amount;
                    break;
                case BonusType.Defence:
                    player.Defence += Amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
