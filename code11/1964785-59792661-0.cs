static void Print(List<Person> Persons)
        {
            if (Persons == null)
            {
                return;
            }
            for (int i = 0; i < Persons.Count; i++)
            {
                Console.WriteLine(Persons[i].ID);
                Print(Persons[i].Siblings);
            }
        }
