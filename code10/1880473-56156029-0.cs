FSharp
open java.nio.charset
open java.io
#I "../packages/OpenNLP.NET/lib/"
#r "opennlp-tools-1.8.4.dll"
#r "opennlp-uima-1.8.4.dll"
open opennlp.tools.util
open opennlp.tools.namefind
let train (inputFile:string) = 
    let factory =
        { new InputStreamFactory with 
            member __.createInputStream () =
                new FileInputStream(inputFile) :> InputStream }
    let lineStream = new PlainTextByLineStream(factory, StandardCharsets.UTF_8)
    use sampleStream = new NameSampleDataStream(lineStream)
    let nameFinderFactory = new TokenNameFinderFactory()
    let trainingParameters = new TrainingParameters();
    //trainingParameters.put(TrainingParameters.ITERATIONS_PARAM, "5");
    //trainingParameters.put(TrainingParameters.CUTOFF_PARAM, "200");
    NameFinderME.train ("en", "person", sampleStream, trainingParameters, nameFinderFactory)
in `C#` the same code may look like this
CSharp
using java.nio.charset;
using java.io;
using opennlp.tools.util;
using opennlp.tools.namefind;
namespace OpenNLP.Train
{
    class MyStreamFactory: InputStreamFactory
    {
        public Factory(string fileName) => _filename = fileName;
        private readonly string _filename;
        public InputStream createInputStream()
            => new FileInputStream(_filename);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new MyStreamFactory("D:\\text.txt");
            var lineStream = new PlainTextByLineStream(factory, StandardCharsets.UTF_8);
            var sampleStream = new NameSampleDataStream(lineStream);
            var nameFinderFactory = new TokenNameFinderFactory();
            var trainingParameters = new TrainingParameters();
            var model = NameFinderME.train("en", "person", sampleStream, trainingParameters, nameFinderFactory);
        }
    }
}
