    public interface roman // there is an interface called "roman", accessible to all
    {
        // all implementations of "roman" must have an "indexer" that takes a string
        // and returns another "roman" instance (it is not required to offer a "set")
        // typical usage:
        //     roman obj = ...
        //     roman anotherObj = obj["abc"];
        roman this[string name] { get; }
    }
    
    public class notempty : roman // there is a class "notempty", accessible to all,
    {                             // which implements the "roman" interface
        // no constructors are declared, so there is a default public parameterless
        // constructor which simply calls the parameterless base-constructor
        // any instance of "notempty" has a string property called "Color" which can
        // be both read (get) and written (set) by any callers; there
        // is also a *field* for this, but the compiler is handling that for us
        public string Color{ get; set; }
    
        // there is an indexer that takes a string and returns a "roman"; since
        // there is no *explicit* implementation, this will also be used to satisfy
        // the "roman" indexer, aka "implicit interface implementation"
        public roman this[string name]
        {
            // when the indexer is invoked, the string parameter is disregarded; a
            // new "notempty" instance is created via the parameterless constructor,
            // and the "Color" property is assigned the string "Value1"; this is then
            // returned as "roman", which it is known to implement
            get { return new notempty() { Color= "Value1" }; }
        }
    }
