    class LootFactory
    {
        const int numLootTypes = 3;
    
        public Loot CreateLoot(Vector2 position)
        {
            Random rand = new Random();
            int lootIndex = rand.Next(numLootTypes);
            if (lootIndex == 0)
            {
                return new HealthPack(position);
            }
            if (lootIndex == 1)
            {
                ...
            }
            ...
        }
    }
