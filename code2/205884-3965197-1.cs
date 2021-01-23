    public interface IThing<T>
    {
       T MyEnum { get; set; }
       string doAction(T enumOptionChosen, string valueToPassIn);
    }
