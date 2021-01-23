    mapping.Component(x => x.DynamicFields, c => c.DynamicComponent(
        Reveal.Member<CustomDictionary, IDictionary>("_innerDictionary"),
        c => {
            c.Map(x => x["fld_num"]).CustomType(typeof(int));
            c.Map(x => x["shortdesc"]).CustomType(typeof(string));
        })
    );
