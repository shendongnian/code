    var last = k.Last();
    k.Aggregate(new StringBuilder(), (sentence, item) => { 
        if (sentence.Length > 0)
        {
            if (item == last)
                sentence.Append(" and ");
            else
                sentence.Append(", ");
        }
        sentence.Append(item.ID).Append(":").Append(item.Name);
        return sentence;
    });
