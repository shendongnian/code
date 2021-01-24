    using System.Collections.Generic;
    using System.Linq;
    ...
    double[][] plots = RMMA(MultiMA1types.VWMA, 2, 160, 10, 2, 128, 0.75, 0.5).Values;
    IEnumerable<double> firstValues = plots.Select(a => a[0]);
    bool allValuesInRange = firstValues.All(v => v < highPrice && v > lowPrice);
