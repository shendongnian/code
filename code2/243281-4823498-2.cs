    double[] runningTotal = textBox_f.Text
                .Split(new char[]{','})
                .Select(s => double.Parse(s))
                .Aggregate((IEnumerable<double>)new List<double>(), 
                           (a,i) => a.Concat(new[]{a.LastOrDefault() + i}))
                .ToArray();
