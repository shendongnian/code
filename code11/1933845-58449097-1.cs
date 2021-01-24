    var rarity = new Dictionary<RarityType, int[]>();
    rarity[RarityType.COMMON] = new int[6];
    rarity[RarityType.RARE] = new int[6];
    rarity[RarityType.EPIC] = new int[6];
    rarity[RarityType.LEGENDARY] = new int[6];
    foreach (RelicModel relic in this.equipedRelics)
    {
        rarity[relic.rarity][relic.Level]++;
    }
