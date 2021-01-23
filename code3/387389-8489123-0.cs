    interface Result {
        boolean success();
    }
    Result objResult = new Result() {
        public boolean success() { return result; }
    };
