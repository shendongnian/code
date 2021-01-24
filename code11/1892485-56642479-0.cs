    private static BasePotion CreatePotion()
    {
        BasePotion newPotion = new BasePotion();
        newPotion.PotionType = ChoosePotionType();
        newPotion.ItemName = newPotion.PotionType.ToString() + " POTION";
        newPotion.ItemID = new Random().Next(1, 100);
        switch (newPotion.PotionType)
        {
            case PotionTypes.HEALTH:
                newPotion.Stamina = new Random().Next(1, 11);
                newPotion.Endurance = new Random().Next(1, 11);
                newPotion.Strength = 0;
                newPotion.Intellect = 0;
                break;
            case PotionTypes.ENERGY:
                newPotion.Stamina = 0;
                newPotion.Endurance = 0;
                newPotion.Strength = new Random().Next(1, 11);
                newPotion.Intellect = new Random().Next(1, 11);
                break;
            case PotionTypes.STAMINA:
                newPotion.Stamina = new Random().Next(1, 11);
                newPotion.Endurance = 0;
                newPotion.Strength = 0;
                newPotion.Intellect = 0;
                break;
            case PotionTypes.ENDURANCE:
                newPotion.Stamina = 0;
                newPotion.Endurance = new Random().Next(1, 11);
                newPotion.Strength = 0;
                newPotion.Intellect = 0;
                break;
            case PotionTypes.STRENGTH:
                newPotion.Stamina = 0;
                newPotion.Endurance = 0;
                newPotion.Strength = new Random().Next(1, 11);
                newPotion.Intellect = 0;
                break;
            case PotionTypes.INTELLECT:
                newPotion.Stamina = 0;
                newPotion.Endurance = 0;
                newPotion.Strength = 0;
                newPotion.Intellect = new Random().Next(1, 11);
                break;
        }
    
        return newPotion;
    }
    private static PotionTypes ChoosePotionType()
    {
        potionType++;
        PotionTypes returnPotion;
        switch (potionType)
        {
            case 1:
                returnPotion = PotionTypes.ENERGY;
                break;
            case 2:
                returnPotion = PotionTypes.HEALTH;
                break;
            case 3:
                returnPotion = PotionTypes.ENDURANCE;
                break;
            case 4:
                returnPotion = PotionTypes.INTELLECT;
                break;
            case 5:
                returnPotion = PotionTypes.STAMINA;
                break;
            case 6:
                returnPotion = PotionTypes.STRENGTH;
                break;
            default:
                returnPotion = PotionTypes.ENERGY;
                break;
        }
    
        return returnPotion;
    }
    public enum PotionTypes
    {
        HEALTH,
        ENERGY,
        STRENGTH,
        ENDURANCE,
        STAMINA,
        INTELLECT
    }
    public class BasePotion
    {
        private PotionTypes potionType;
        private int spellEffectID;
    
        public int Intellect { get; internal set; }
        public int ItemID { get; internal set; }
        public string ItemName { get; internal set; }
    
        public PotionTypes PotionType
        {
            get { return potionType; }
            set { potionType = value; }
        }
    
        public int SpellEffectID
        {
            get { return spellEffectID; }
            set { spellEffectID = value; }
        }
    
        public int Strength { get; internal set; }
        public int Stamina { get; internal set; }
    
        public int Endurance { get; internal set; }
    
        public override string ToString()
        {
            return $"ItemID:{ItemID}, ItemName:{ItemName}, PortionType:{PotionType.ToString()}, SpellEffect:{SpellEffectID}, Strength:{Strength}, Stamina:{Stamina}, Endurance: {Endurance}, Intellect: {Intellect}.";
        }
    }
