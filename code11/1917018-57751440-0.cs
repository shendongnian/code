   <td>
        @{ 
             double sumHits = item.Sum(m => m.stat.hits);
             double sumAb = item.Sum(m => m.stat.AB);
             double result = sumHits / sumAb;
             if (sumAb > 0)
                {
                    double result = sumHits / sumAb;
                    <Span>@result</Span>
                }
          }
    </td>
