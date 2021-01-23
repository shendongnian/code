    var groups = myList.GroupBy(x => 
        { 
            var parts = x.Split('.'));
            int num = 0;
            return parts[0] + parts.Where(p => p.All(char.IsDigit)
                                   .First( p => int.TryParse(p, out num));
        }
    );
