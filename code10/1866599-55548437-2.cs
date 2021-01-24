    string stra = "á";
    string strFormD = stra.Normalize(NormalizationForm.FormD);
    var result = Regex.Replace(strFormD, @"\p{M}", string.Empty);
                
    Console.WriteLine("a".Equals(result)); // True
    Console.WriteLine("a" == result); // True
