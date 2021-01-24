var writers = new Dictionary<string, TextWriter>();
const string header = "COMPANY CODE;CUSTOMER NUMBER;CUSTOMER NAME;INSERT DATE;TRANSACTION ID;TRANSACTION AMOUNT;ADMIN FEE;TRANSACTION REF;FLAG STATUS;TRANSACTION STATUS";
const string inputFile = "X:\\exampledata.txt";
const string outputPath = "C:\\Users\\Desktop\\VA\\";
using (var reader = File.OpenText(inputFile))
{
	// skip header
	reader.ReadLine();
	try
	{
		while (!reader.EndOfStream)
		{
			// read one line and separate key and value
			var line = reader.ReadLine();
			var separatorIndex = line.IndexOf(';');
			var id = line.Substring(0, separatorIndex);
			var value = line.Substring(separatorIndex + 1);
			// get a writer or create one
			if (!writers.TryGetValue(id, out var writer))
			{
				writer = File.CreateText($"{outputPath}{id}.txt");
				writer.WriteLine(header);
				writers.Add(id, writer);
			}
			// write the line to the correct file
			writer.WriteLine(value);
		}
	}
	finally
	{
		// dispose all the writers
		foreach (var writer in writers.Values)
		{
			writer.Dispose();
		}
	}
}
