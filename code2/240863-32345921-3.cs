    class Verb
    {
        string uniqueID;
        List<string> values;
    }
    class Object
    {
        public uniqueID; // Because this is shared with Verbs, you could do a better unique ID system, but hey...
	    public List<string> articles;
	    public List<string> adjectives;
	    public List<string> noun;
    }
