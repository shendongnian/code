none
timeFor5Million = timeFor10000 / 10000 / 10000 * 5000000 * 5000000
                = timeFor10000 * 250000
---
#Results
* Four `foreach` blocks:
    Average time = 48628ms; estimated time for 5 million sets = 3377 hours
    
        var result = new Dictionary<SetWithRange, int>();
        foreach ( var setA in groupA )
        {
            int maxcount = 0;
            foreach ( var setB in groupB )
            {
                int count = 0;
                foreach ( var elementA in setA )
                {
                    foreach ( int elementB in setB )
                    {
                        if ( elementA == elementB )
                            count++;
                    }
                }
                if ( count > maxcount ) maxcount = count;
            }
            result.Add(setA, maxcount);
        }
* Three `foreach` blocks with parallelisation on the outer `foreach`:
    Average time = 10305ms; estimated time for 5 million sets = 716 hours (4.7 times faster than original):
        var result = new Dictionary<SetWithRange, int>();
        Parallel.ForEach(groupA, setA =>
        {
            int maxcount = 0;
            foreach ( var setB in groupB )
            {
                int count = 0;
                foreach ( var elementA in setA )
                {
                    foreach ( int elementB in setB )
                    {
                        if ( elementA == elementB )
                            count++;
                    }
                }
                if ( count > maxcount ) maxcount = count;
            }
            lock ( result )
                result.Add(setA, maxcount);
        });
* Using `HashSet<int>` and adding a `Range` to only check sets which intersect:
    Average time = 375ms; estimated time for 5 million sets = 24 hours (130 times faster than original):
        var result = new Dictionary<SetWithRange, int>();
        Parallel.ForEach(groupA, setA =>
        {
            var commonValues = groupB.Max(setB => setA.CommonValuesWith(setB));
            lock ( result )
                result.Add(setA, commonValues);
        });
    Link to a working online demo here: https://dotnetfiddle.net/Kxpagh (note that .NET Fiddle limits execution times to 10 seconds, and that for obvious reasons its results are slower than running in a normal environment).
