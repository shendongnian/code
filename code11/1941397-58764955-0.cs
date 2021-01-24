cs
public class FrProcessor : Processor {
	protected override string Separator => ".";
	
	protected override string ProcessSpecific(string text) {
		text.Replace("é", "e");
	}
}
public class UsaProcessor : Processor {
	protected override string Separator => ",";
	
	protected override string ProcessSpecific(string text) {
		text.Capitalise();
		text.RemovePunctuation();
	}
}
And one base class to handle common parts of the processing:
cs
public abstract class Processor {
	protected abstract string Separator { get; }
	
	protected virtual string ProcessSpecific(string text) { }
	
	private string ProcessCommon(string text) {
        var split = text.Split(Separator);
        string.Join("|", split);
	}
	
	public string Process(string text) {
		ProcessSpecific(text);
		ProcessCommon(text);
	}
}
