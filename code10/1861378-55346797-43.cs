		var reduced = 
        loc.Select(x => new Reduced() {
        Key = x.Key,                 
                invalid =
                    x.Where(y => loc.Any(ext => ext.Any(xsup =>
                       y.All(z => xsup.Any(xsupcell => xsupcell.Key == z.Key)) &&
                       y.All(z =>
                       z.Val <= xsup
                             .Where(xsupcell =>
                       xsupcell.Key == z.Key)
                             .First().Val) &&
                             ((xsup.Length > y.Length) ||
                       y.Any(z =>
                       z.Val < xsup
                             .Where(xsupcell =>
                       xsupcell.Key == z.Key)
                             .First().Val))
                        ))).ToArray()
                                });
        var remain = loc.Select(x => x.Where(y =>
        !reduced.Where(r => r.Key == x.Key).SelectMany(r2 => r2.invalid).Any(r3 => r3.All(r4 =>
        y.Any(y2 => y2.Key == r4.Key && y2.Val == r4.Val)))));
