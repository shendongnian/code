    List<List<double>> listoflists = new List<List<double>>();
    listoflists.Add(big_list.GetRange(0, 8));//Retrieves 8 items starting with index '0'
    listoflists.Add(big_list.GetRange(8, 9));//Retrieves 9 items starting with index '8'            
    for(int i=0; i<listoflists.Count;i++){
        for(int j=0; j<listoflists[i].Count; j++){
            Console.Write(listoflists[i][j] + "  ");
        }
        Console.WriteLine();
    }
