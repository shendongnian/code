    public List<DomainSensorEvent> GetDomainSensorEvents()
    {
        return DbContext.SensorEvent
        .Include("Sensor")
        .Include("SensorData")
        .Include("Sensor.SensorPlacement")
        .Where(w => w.Sensor.SensorPlacement.Where(sp => w.RecordTime > sp.From 
            && (sp.To == null || w.RecordTime < sp.To)))
        .ToList();        
    }
