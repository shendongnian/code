    const float MinDistanceSqr = 0.00001f; // Min Distance of 0.001 (1mm)
    const float MaxCosine = 0.999f; // Approx 2.57 degrees
    private Vector3[] FilterPoints(Vector3[] source) {
        var filtered = new Stack<Vector3>(source.Length);
        // Push first point
        filtered.Push(source[0]);
        for ( var i = 1; i < source.Length; i++ ) {
            var step = filtered.Peek() - source[i];
            // Check Minimum Distance
            if (step.sqrMagnitude < MinDistanceSqr)
                continue; // ignore this point
            // if not last point
            if ( i + 1 < source.Length) {
                // Check Minimum Angle to next segment
                var nextStep = source[i] - source[i + 1];
                if (Vector3.Dot(step, nextStep) > MaxCosine)
                    continue; // ignore this point
            }
            // Passed all filters, add to stack
            filtered.Push(source[i]);
        }
        return filtered.ToArray();
    }
