	public class MyClass : ILoggable {
		void MyMethod() {
			ILoggable loggable = this;
			loggable.Log("Using injected logging");
		}
	}
