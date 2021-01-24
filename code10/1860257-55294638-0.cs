    public interface ICode { }
    
    public interface IPreparedCode<TCode>
        where TCode : ICode { }
    
    public interface ILayer<TPreparedCode, TCode>
    	where TCode : ICode
        where TPreparedCode : IPreparedCode<TCode> { }
    
    public interface IContext<TCode, TPreparedCode, TLayer>
        where TCode : ICode
        where TPreparedCode : IPreparedCode<TCode>
        where TLayer : ILayer<TPreparedCode, TCode> { }
