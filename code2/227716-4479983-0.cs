    [Serializable]
    public struct StringType_DEFAULT : IObjectReference {
    public object GetRealObject(StreamingContext context) {
        return StringType.DEFAULT;
    }
    }
    [Serializable]
    public struct StringType_UNSET : IObjectReference {
    public object GetRealObject(StreamingContext context) {
        return StringType.UNSET;
    }
    }
