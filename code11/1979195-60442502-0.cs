    using(var insertContext = new MyAppContext())
    {
        foreach (EcgDTO.HrvData data in u.hrvData)
        {
            if (data.hrv == null && data.hrv.Count == 0)
                continue;
            foreach (String d in data.hrv)
            {
                ECG ecg = new ECG
                {
                    Id = id++;
                    IdPerson = idPatient;
                    y = Decimal.Parse(d);
                    timestamp = data.createdDate;
                };
                insertContext.ECG.Add(ecg);
            }
        }
        int savedData = insertContext.SaveChanges();
    }
