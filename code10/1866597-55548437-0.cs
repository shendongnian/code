    string stra = "á";
    string strFormC = stra.Normalize(NormalizationForm.FormC);
    string strFormD = stra.Normalize(NormalizationForm.FormD);
    string strFormKC = stra.Normalize(NormalizationForm.FormKC);
    string strFormKD = stra.Normalize(NormalizationForm.FormKD);
    Console.WriteLine("C {0}", strFormC.Length); // 1
    Console.WriteLine("D {0}", strFormD.Length); // 2
    Console.WriteLine("KC {0}", strFormKC.Length); // 1
    Console.WriteLine("KD {0}", strFormKD.Length); // 2
    Console.WriteLine("a".Equals(strFormD[0].ToString())); // True
    Console.WriteLine("a".Equals(strFormKD[0].ToString())); // True
