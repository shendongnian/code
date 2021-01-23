    [Serializable]
    public class Template : ISerializable, IDeserializationCallback
    {
    	private List<Tuid> tuids;
    	private List<Section> sections
    	protected Template(SerializationInfo info, StreamingContext context)
        {
    		tuids = (List<Tuid>)info.GetValue("Sections_Keys", typeof(List<Tuid>));
            sections = (List<Section>)info.GetValue("Sections_Values", typeof(List<Section>));
            this._sections = new Dictionary<Tuid, Section>();
    	}
    		
        public void OnDeserialization(object sender)
        {
    		// Section serialization constructor should have been called by this point
    		for (int i = 0; i < tuids.Count; i++)
            {
                _sections.Add(tuids[i], sections[i]);
            } 
    	}
    }
