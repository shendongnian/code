    typeof(A).GetProperties().OrderBy(p => p.Name)
        .Zip(typeof(B).GetProperties().OrderBy(p => p.Name),
        ((aInfo, bInfo) => !aInfo.GetValue(objA).Equals(bInfo.GetValue(objB))
            ? new C() 
            { 
                ColumnName = aInfo.Name,
                oldValue = aInfo.GetValue(objA).ToString(), 
                newValue = bInfo.GetValue(objB).ToString()
            }
            : null))
        .Where(x => !(x is null)).ToList();
