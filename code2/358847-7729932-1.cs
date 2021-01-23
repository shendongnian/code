    public class CompoundWriter:TextWriter
    {
        public readonly List<TextWriter> Writers = new List<TextWriter>();
    
        public override void WriteLine(string line)
        {
            if(Writers.Any())
                foreach(var writer in Writers)
                    writer.WriteLine(line);
        }
    
        //override other TextWriter methods as necessary
    }
    ...
    
    //When the program starts, get the default Console output stream
    var consoleOut = Console.Out;
    
    //Then replace it with a Compound writer set up with a file writer and the normal Console out.
    var compoundWriter = new CompoundWriter();
    compoundWriter.Writers.Add(consoleOut);
    compoundWriter.Writers.Add(new TextWriter("c:\temp\myLogFile.txt");
    
    Console.SetOut(compoundWriter);
    
    //From now on, any calls to Console's Write methods will go to your CompoundWriter,
    //which will send them to the console and the file.
