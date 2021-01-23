    interface Result
    {
        bool getSuccess();
    }
    Result objResult = new Result() {
        bool getSuccess() { return result; }
    }
