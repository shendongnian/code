    typeof(A).GetProperties().OrderBy(p => p.Name)
        .Zip(typeof(B).GetProperties().OrderBy(p => p.Name),
        ((aInfo, bInfo) => !aInfo.GetValue(objA).Equals(bInfo.GetValue(objB))
            ? new
            { 
                ColumnName = aInfo.Name,
                oldValue = aInfo.GetValue(objA), 
                newValue = bInfo.GetValue(objB)
            }
            : null))
        .Where(x => !(x is null)).ToList();
