    interface Result
    {
        bool getSuccess();
    }
    // ...
    bool result = DoSomething();
    Result objResult = new Result() {
        bool getSuccess() { return result; }
    }
