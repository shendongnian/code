    private ChildClass<GenericType> initializeParameter<GenericType>(ChildClass<GenericType> inputParameter, ExternalObject value){
        ChildClass<GenericType> populatedParameter = null;
        if(inputParameter != null){
           populatedParameter = new ChildClass<GenericType>(parameter.name, parameter.type, value, parameter.mappingFunction);
        }
        return populatedParameter
    }
