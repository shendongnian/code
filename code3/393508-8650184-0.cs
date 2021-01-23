    // This is mainly declared to ease use as a User Setting
    public class SpellSourceCollection : List<SpellSource>
    {
    	public SpellSourceCollection() : base() { }
    	public SpellSourceCollection(IEnumerable<SpellSource> ListToCopy)
    		: this()
    	{
    		this.AddRange(ListToCopy);
    	}
    }
