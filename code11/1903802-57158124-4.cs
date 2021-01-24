    string SwapAlternateNumbers(string numbersInput) {
        var wholeSeries = numbersInput.Split(' ').ToList();
        var halfTheNumbers = wholeSeries.Count / 2;
        if (halfTheNumbers % 2 !== 0) {
            throw new InvalidOperationException("I'm not handling this use case for you.");
        }
        var result = new StringBuilder();
        for(var i = 0; i < halfTheNumbers; i += 2) {
            // append the _second_ number
            result.Append(wholeSeries[i+1]).Append(" ");
            // append the _first_ number
            result.Append(wholeSeries[i]).Append(" ");
        }
        // assuming you want the whole thing as a string
        return result.ToString();
    }
