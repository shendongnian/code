    private IEnumerable<ClassLib.CarSegment>
        GetModels(IEnumerable<ClassLib.CarSegment> segments, string modelID)
    {
        return segments.Where(x => x.Class.IndexOfAny(modelID) == 0);
    }
    
    // ...
    var bmwSegments = CarSegmentFactory.ContainsCar("BMW").ToArray();
    
    bool isValid = bmwSegments.Any();
    var olderModelSegments = GetModels(bmwSegments, lowerModels);
    var newerModelSegments = GetModels(bmwSegments, upperModels);
