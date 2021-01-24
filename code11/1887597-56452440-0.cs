	public static void Main()
	{
		var yaml = @"
	pets:  
	- !Cat
	  name: skippy
	  likesMilk: true
	- !Cat
	  name: felix
	  likesMilk: true
	- !Dog
	  name: ralf
	  likesBones: true
	- !Hamster
	  name: Hamtaro
	  likesTv: true
	...
	";
		
		var stream = new YamlStream();
		stream.Load(new StringReader(yaml));
		stream.Save(new MappingFix(new Emitter(Console.Out)), false);
	}
    public class MappingFix : IEmitter
    {
    	private readonly IEmitter next;
    
    	public MappingFix(IEmitter next)
    	{
    		this.next = next;
    	}
    
    	public void Emit(ParsingEvent @event)
    	{
    		var mapping = @event as MappingStart;
    		if (mapping != null) {
    			@event = new MappingStart(mapping.Anchor, mapping.Tag, false, mapping.Style, mapping.Start, mapping.End);
    		}
    		next.Emit(@event);
    	}
    }
