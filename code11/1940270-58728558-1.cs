var a = new EventWithObjectsDto {Type = "Tip"};
EventDto b = a;
var c = (EventWithObjectsDto) b;
Console.WriteLine(c.Type);
Output is:
Tip
----
# Making an `EventWithObjectsDto` from `EventDto`. 
While you cannot cast an object of class `EventDto` to `EventWithObjectsDto`, you can always create an object of derived type from an object of the parent type. 
public class EventWithObjectsDto : EventDto
{
    public List<string> Objects { get; set; }
    public static EventWithObjectsDto FromEvent(EventDto p) {
        return new EventWithObjectsDto(...);
    }
}
