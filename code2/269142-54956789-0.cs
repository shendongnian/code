    public class Signal<T>{
       protected string Id {get; set;} //This must be here, I use a property because MemberInfo is returned in an array via GetMember() reflection function
       //Some Data and Logic And stuff that involves T
    }
    
    public class OnClick : Signal<string>{}
