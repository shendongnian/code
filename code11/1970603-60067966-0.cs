        void IterateTable<T>(Dictionary<int, Animal> animals) where T : Animal
        {
            foreach (KeyValuePair<int, Animal> entry in animals)
            {
                if (entry.Value is T)
                {
                    entry.Value.Attack();
                }
            }
        }
        void IterateTable(Dictionary<int, Animal> animals)
        {
            foreach (KeyValuePair<int, Animal> entry in animals)
            {
                entry.Value.Attack();
            }
        }
