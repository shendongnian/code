    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Combat
    {
        class Program
        {
            static void Main(string[] args)
            {
                Combatant swastik = new Combatant();
                swastik.CombatantInitialize("Swastik", "Bhattacharyya", 0);
                Combatant ankit = new Combatant();
                ankit.CombatantInitialize("Ankit", "Gupta", 1);
                List<Combatant> list = new List<Combatant>();
                list.Add(swastik);
                list.Add(ankit);
                Random rndIndex = new Random();
                var idxGet = rndIndex.Next(0, list.Count);
                Console.WriteLine( array[idxGet].fullName );
            }
        }
        class Combatant
        {
            public string firstName;
            public string lastName;
            public string fullName;
            public int index;
            public void CombatantInitialize(string fName, string lName, int ind)
            {
                firstName = fName;
                lastName = lName;
                index = ind;
                fullName = firstName + " " + lastName;
            }
        }
    }
