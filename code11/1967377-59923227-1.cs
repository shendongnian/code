using System;
using System.Collections.Generic;
using System.Linq;
public class Chromosome
{
   Dictionary<string, DNA> chromosomes;
   public IEnumerable<DNA<T>> GetDNAOfType<T>()
   {
      return chromosomes.OfType<DNA<T>>();
   }
}
public abstract class DNA
{
}
public class DNA<T> : DNA
{
   public T[] Genes { get; private set; }
}
