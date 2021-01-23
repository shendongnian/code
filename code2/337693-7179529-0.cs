    public class LogMapping : Mapping<Log> {
    	public LogMapping(int year) {
    		Named("Logs" + year);
    		//Column mappings...
    	}
    }
