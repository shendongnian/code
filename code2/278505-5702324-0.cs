    class Player
    {
       public string Name { get; set; }
       public string SpellData { get; set; }
       
       public int[] Spells() {
            return SpellData.Split(" ").select(n=>int.parse(n)).ToArray();
       };
    }
