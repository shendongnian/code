    public static class IEnumerableExt {
        public static IEnumerable<UnpivotData> Unpivot<T>(this IEnumerable<T> src, string[] pivotFieldNames, string unPivotName, string unPivotValue, Func<string, bool> unpivotFieldNameFn) {
            var srcPIs = typeof(T).GetProperties();
            var srcPivotPIs = srcPIs.Where(pi => pivotFieldNames.Contains(pi.Name));
            var ansPIs = typeof(UnpivotData).GetProperties();
            var ansPivotPIs = ansPIs.Where(pi => pivotFieldNames.Contains(pi.Name));
            var srcAnsPivotPIs = srcPivotPIs.Zip(ansPivotPIs, (spi, api) => new { spi, api }).ToList();
            var srcUnpivotPIs = srcPIs.Where(pi => unpivotFieldNameFn(pi.Name)).ToList();
            var unPivotNamePI = ansPIs.First(pi => pi.Name == unPivotName);
            var unPivotValuePI = ansPIs.First(pi => pi.Name == unPivotValue);
    
            foreach (var d in src) {
                var ansbase = new UnpivotData();
                foreach (var sapi in srcAnsPivotPIs)
                    sapi.api.SetValue(ansbase, sapi.spi.GetValue(d));
    
                foreach (var spi in srcUnpivotPIs) {
                    var ans = ansbase.ShallowCopy();
                    unPivotNamePI.SetValue(ans, spi.Name);
                    unPivotValuePI.SetValue(ans, spi.GetValue(d));
    
                    yield return ans;
                }
            }
        }
    }
