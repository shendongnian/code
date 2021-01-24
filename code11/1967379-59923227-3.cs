using System;
using System.Collections.Generic;
using System.Linq;
public class Chromosome
{
   Dictionary<string, DNA> chromosomes = new Dictionary<string, DNA>();
   public IEnumerable<DNA<T>> GetDNAOfType<T>()
   {
      return chromosomes.Values.OfType<DNA<T>>();
   }
   public void AddDNA(string key, DNA dna)
   {
      if (chromosomes.ContainsKey(key))
         chromosomes[key] = dna;
      else
         chromosomes.Add(key, dna);
   }
}
public abstract class DNA
{
}
public class DNA<T> : DNA
{
   public T[] Genes { get; private set; }
}
