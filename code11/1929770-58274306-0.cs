        class Program
        {
            static void Main(string[] args)
            {
                ItemMenu menu = GetSteakMenu();
                var results = menu.Modifiers.SelectMany(x => x.Options.Select(y => new {
                    modifierName = x.Name,
                    modifierMandatory = x.IsMandatory,
                    id = y.ID,
                    optionName = y.Name,
                    selected = y.Selected
                }))
                .GroupBy(x => x.id)
                .Select(x => x.Select(y => y).ToList())
                .ToList();
            }
            public static ItemMenu GetSteakMenu()
            { 
                return new ItemMenu
                {
                    Name = "Beef Steak",
                    Modifiers = new List<Modifier> {
                        new Modifier {  Name = "Temperature", IsMandatory = true, Options = new List<ModifierOption>
                            {
                                new ModifierOption { ID = 1, Name = "Rare" },
                                new ModifierOption { ID = 2, Name = "Medium" },
                                new ModifierOption { ID = 3, Name = "Well done" },
                            }
                        },
                        new Modifier {  Name = "Side", Options = new List<ModifierOption>
                            {
                                new ModifierOption { ID = 1, Name = "Salad" },
                                new ModifierOption { ID = 2, Name = "Fries" },
                                new ModifierOption { ID = 3, Name = "Sweet fries" },
                            }
                        },
                        new Modifier {  Name = "Drink", Options = new List<ModifierOption>
                            {
                                new ModifierOption { ID = 1, Name = "Beer" },
                                new ModifierOption { ID = 2, Name = "Wine" },
                                new ModifierOption { ID = 3, Name = "Coke" },
                            }
                        }
                    }
                };
            }
        }
        public class ItemMenu
        {
            public string Name { get; set; }
            public List<Modifier> Modifiers { get; set; }
        }
        public class Modifier
        {
            public bool IsMandatory { get; set; }
            public string Name { get; set; }
            public List<ModifierOption> Options { get; set; }
        }
        public class ModifierOption
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }
