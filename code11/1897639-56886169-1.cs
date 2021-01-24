    public IList<double> Calculate(Product product)
            {
                IList<double> cumulativeDataTriangle = new List<double>();
                if (!product.ProductIncrementalValues.Any())
                    return cumulativeDataTriangle;
    
                var lookup = product.ProductIncrementalValues.
                    ToDictionary(v => (v.OriginYear, v.DevelopmentYear), v => v.IncrementalValue);
                for (int i = 0; i < product.NoOfDevelopmentYears; i++)
                {
                    var originYear = product.EarliestOriginYear + i;
                    double previous = 0;
                    for (int j = 0; j < product.NoOfDevelopmentYears - i; j++)
                    {
                        var developmentYear = originYear + j;
                        double incrementalValue;
                        lookup.TryGetValue((originYear, developmentYear), out incrementalValue);
    
                        var tmp = incrementalValue + previous;
                        cumulativeDataTriangle.Add(tmp);
                        previous = tmp;
                    }
                }
    
                return cumulativeDataTriangle;
            }
