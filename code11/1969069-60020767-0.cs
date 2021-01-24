    string[] cases= Directory.GetFiles(CasesDir), solCases=Directory.GetFiles(Path.Combine(CasesDir,"sol"));
            string[] singleCase,singleSolCase;
            string salida;
            int i=0;
    foreach(string file in cases){
                Console.WriteLine("\nCase "+(i+1).ToString());
                
                p.Start();
                singleCase=File.ReadAllLines(file);
                foreach(string line in singleCase){
                    p.StandardInput.WriteLine(line);
                }
                singleCase=null;
                p.StandardInput.Close();
                p.WaitForExit();
                singleSolCase=File.ReadAllLines(solCases[i]);
                foreach(string line in singleSolCase){
                    if(p.StandardOutput.EndOfStream){
                        Console.WriteLine("=X Output incomplete");
                        break;
                    }
                    testerOutput=p.StandardOutput.ReadLine();
                    if(string.Compare(salida,line)!=0){
                        Console.WriteLine("=X Wrong Output\n"+"Solution: "+line+"\nOutput: "+salida);
                    }
                }
                singleSolCase=null;
                i++;
            }
