	public class MyProgram 
	{ 
		static public void Main(string[] args) 
		{
			var processor = new ProcessBassTypeClass();
			processor.Process( new BaseTypeClass() );
			processor.Process( new BaseTypeV1() );
			processor.Process( new BaseTypeV2() );
			processor.Process( new BaseTypeV3() );
		} 
	} 
