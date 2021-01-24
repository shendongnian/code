cs
public class FrProcessor : Processor {
	protected override string Separator => ".";
	
	protected override string ProcessSpecific(string text) {
		return text.Replace("é", "e");
	}
}
public class UsaProcessor : Processor {
	protected override string Separator => ",";
	
	protected override string ProcessSpecific(string text) {
		return text.Capitalise().RemovePunctuation();
	}
}
And one base class to handle common parts of the processing:
cs
public abstract class Processor {
	protected abstract string Separator { get; }
	
	protected virtual string ProcessSpecific(string text) { }
	
	private string ProcessCommon(string text) {
        var split = text.Split(Separator);
        return string.Join("|", split);
	}
	
	public string Process(string text) {
		var s = ProcessSpecific(text);
		return ProcessCommon(s);
	}
}
Also, you should rework your return types because it won't compile as you wrote them - sometimes a `string` method doesn't return anything.
