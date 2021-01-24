    public string OutStanding(string PC)
    {
        var rawData = _context.MyTable.Where(w => w.debit == PC || w.credit == PC)
                                                              //^^ using OR operator 
        var d = rawData.Where(w => w.debit == PC).Sum(s => s.amount);
        var c = rawData.Where(w => w.credit== PC).Sum(s => s.amount);
        return (d - c).ToString();
    }
