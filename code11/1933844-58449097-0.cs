    var rarity = new Dictionary<RarityType, int[]>();
    rarity[RarityType.COMMON] = new int[5];
    rarity[RarityType.RARE] = new int[5];
    rarity[RarityType.EPIC] = new int[5];
    rarity[RarityType.LEGENDARY] = new int[5];
    foreach (RelicModel relic in this.equipedRelics)
    {
        rarity[relic.rarity][relic.Level]++;
    }
