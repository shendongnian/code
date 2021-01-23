    class JsonDto
   
    string Content {get;set;}
    string Type {get;set;}
    ctor(object) => sets Content & Type Properties
    static JsonDto FromJson(string) // => Reads a Serialized JsonDto 
                                          and sets Content+Type Properties
    string ToJson() // => serializes itself into a json string
    object Deserialize() // => deserializes the wrapped object to its saved Type
                               using Content+Type properties
    T Deserialize<T>()   // deserializes the object as above and tries to cast to T
