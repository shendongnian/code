    class LoggerTestcase {
        public Logger Logger {get;set;}
        public Testcase Testcase {get;set;}
    }
    var query = from logger in database.LOGGERs
        join testcase in database.TESTCASEs on logger.TCID equals 
        testcase.TCID select new LoggerTestcase {Logger = logger, Testcase = testcase};
