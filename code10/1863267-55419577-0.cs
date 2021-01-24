    public class ComboFactory
    {
        public static SuperCombo GetComboClassInstance(string comboCode)
        {
            switch(comboCode)
            {
                case "A":
                    return new ComboA();
                case "B":
                    return new ComboB();
                //and so on
            }
        }
    }
