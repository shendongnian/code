cs
NotificheDiStatoModel outputreq = new NotificheDiStatoModel();
var senors = new List<SensorStatus>();
var acceptedSensorIds = new List<string> {"blestatus","bleenabled","clessstatus","clessenabled","qrstatus"};
foreach (var sensore in senors)
{
	acceptedSensorIds.ForEach(id =>
	{
		if (sensore.SensorId.Equals(id, StringComparison.OrdinalIgnoreCase))
		{
			var propertyInfo = outputreq.GetType().GetProperty(id);
			propertyInfo.SetValue(outputreq,Convert.ToBoolean(sensore.SensorValue));
		}
	});
}
