    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication135
    {
        class Program
        {
            static ItemMenu menu = null;
            static List<List<ModifierOption>> modifiers = new List<List<ModifierOption>>();
            static void Main(string[] args)
            {
                menu = GetSteakMenu();
                GetRecursive(0, null);
            }
            static void GetRecursive(int level, List<ModifierOption> all)
            {
                foreach (ModifierOption option in menu.Modifiers[level].Options)
                {
                    List<ModifierOption> newList = new List<ModifierOption>();
                    if(all != null) newList.AddRange(all);
                    newList.Add(option);
                    if (level == menu.Modifiers.Count - 1)
                    {
                        modifiers.Add(newList);
                    }
                    else
                    {
                        GetRecursive(level + 1, newList);
                    }
                }
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
     
    }
