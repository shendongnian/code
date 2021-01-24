    static T[] MySlice<T>(T[] array, Range r)
    {
        //Transforms indexes "from end" to indexes "from start"    
        if(r.Start.ToString()[0] == '^'){
            var startIdx = array.Length - r.Start.Value;
            r = new Range(startIdx,r.End);
        }
        if(r.End.ToString()[0] == '^'){
            var endIdx = array.Length - r.End.Value;
            r = new Range(r.Start,endIdx);
        }
        //Check if start value is greater than end value. If so, invert it
        if(r.Start.Value > r.End.Value)
        {                
            r = new Range(r.End,r.Start);
            var invArr = array[r];
            Array.Reverse(invArr);
            return invArr;
        }
        return array[r];
    }
