    public void Update(Programme record)
    {
        var missingRows = dB.ProgrammeRows.Where(i => i.ProgrammeId == record.ProgrammeId)
                            .Except(record.Rows);
        dB.ProgrammeRows.RemoveRange(missingRows);
    
        dB.Programmes.Update(record);
        dB.SaveChanges();
    }
