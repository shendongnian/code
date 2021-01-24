    using System.Linq;
    // ...
    Vector3 DirectionRandomizer(DirectionFactor factor)
    {
        DirectionFactor[] candidates = selectableFactors;
        if (factor != DirectionFactor.Start)
        {
            // ignore the one that is two away in value
            candidates = selectableFactors.Where(x => 
                    Mathf.Abs(previousFactor - x) != 2).ToArray();
        }
    
        previousFactor = candidates[Random.Range(0, candidates.Length)];
        int factorIndex = (int)previousFactor;
        return factorDict[factorIndex];
    }
