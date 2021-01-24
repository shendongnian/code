csharp
public static List<Phrase> viewablePhrases
{
   new Phrase(/* your constructor */)
   // other your Phrase objects
};
for(int i = 0; i < viewablePhrases.Count; i++)
{
    Console.WriteLine(viewablePhrases[i].Value); // or other property instad of "Value"
}
