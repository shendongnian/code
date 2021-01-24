    class Program
    {
        List<Combatant> combatList = new List<Combatant>();
        static void Main(string[] args)
        {
            Combatant swastik = new Combatant();
            swastik.CombatantInitialize("Swastik", "Bhattacharyya", 0);
            //add item to list
            combatList.Add(swastik);
            Combatant ankit = new Combatant();
            ankit.CombatantInitialize("Ankit", "Gupta", 1);
            //add item to list
            combatList.Add(ankit);
            Random rndIndex = new Random();
            var idxGet = rndIndex.Next(0, combatList.Count);
            //Output firstname to console
            Console.WriteLine(combatList[idxGet].firstName);
        }
    }
