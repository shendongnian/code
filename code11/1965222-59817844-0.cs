     public void printToFile(List<string> allPermutations) { 
        using (StreamWriter sw = new StreamWriter("names.txt")){
              foreach (string s in allPermutations){
                        sw.WriteLine(s);
              }
        }
     }
