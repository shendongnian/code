    //If we pass in type of filemetabaseobject, because all file metas inherit from it, and we have exposed an overridde property of "value" to all objects, we can just consult that on all types (where lequation is the string representing the equation):
    var z = System.Linq.Dynamic.DynamicExpression.ParseLambda(typeof(FileMeta.Filemetabaseobject), typeof(bool), lequation);
    //invoke the query - true will be returned if the query is valid against the property(ies) exposes
    bFound = (bool)z.Compile().DynamicInvoke(t); //where t is my filetag that I'm querying against, but could be anything that inherits from filemetabaseobject
                            
