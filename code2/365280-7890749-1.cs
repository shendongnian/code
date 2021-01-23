    public static bool IsWalkable(this Materials myMat )
    {
        return myMat == Materials.Earth || myMat == Materials.Wood || myMat == Materials.Stone; 
        // alternatively:
        return new[] { Materials.Earth,  Materials.Wood,  Materials.Stone }.Contains(myMat);
    }
