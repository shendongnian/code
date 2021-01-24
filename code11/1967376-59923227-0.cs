public class Chromosome
{
   Dictionary<string, IDNA> chromosomes;
   public IEnumerable<DNA<T>> GetDNAOfType<T>()
   {
      return chromosomes.OfType<DNA<T>>();
   }
}
public interface IDNA
{
}
public class DNA<T> : IDNA
{
   public T[] Genes { get; private set; }
}
