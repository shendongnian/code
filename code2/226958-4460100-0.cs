    @WebService
    public interface IDartProxy {
        @WebMethod  
        String run(@WebParam(name = "s") String s);
    }
