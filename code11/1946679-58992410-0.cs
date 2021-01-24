cs
public enum SensorIdEnum {
	blestatus,
	bleenabled,
	clessstatus,
	...
}
Your `SensorStatus` class would become:
cs
public class SensorStatus
{
    [Required]
    public SensorIdEnum SensorId { get; set; }
    public string SensorValue { get; set; }
}
This would reduce risk of typo and make documentation and extension easier.
Then, I would use generics to enforce a type on the `SensorValue` property right from the start.
cs
public class SensorStatus<T>
{
    [Required]
    public SensorIdEnum SensorId { get; set; }
    public T SensorValue { get; set; }
}
This way you're making the data conversion the responsibility of the `SensorStatus` itself (in its constructor maybe).
And you could make your `outputreq` basically a `Dictionary<SensorIdEnum, object>` that you pass around instead of a full fledged `NotificheDiStatoModel` class that you don't necessarily fully use:
cs
var listasensori = req.MessageBody.SensorsStatus;
var outputreq = new Dictionary<SensorIdEnum, object>();
foreach (var sensore in listasensori)
{                   
    outputreq[sensore.SensorId] = sensore.SensorValue;
};
