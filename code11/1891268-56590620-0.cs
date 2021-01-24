    using System;
    using System.Collections.Generic;
    class MainClass {
        public static void Main (string[] args) {
            int[] array = { 1, 6, 3, 2, 5, 5, 7, 8, 4, 8, 2, 5, 9, 9, 1 };
            int x = 10;
            // build dictionary
            Dictionary<int,int> dict = new   Dictionary<int,int>();
            for(int i=0; i< array.Length; i+=1){
                if(dict.ContainsKey(array[i])){
                    dict[array[i]] += 1;
                } else {
                    dict.Add(array[i], 1);
                }
            }
            // using dictionary
            for(int i=0; i< array.Length; i+=1){
                if(dict.ContainsKey(x - array[i])) {
                    int count = dict[x - array[i]];
                    if(x - array[i] == array[i]){
                        count -= 1;
                    }
                    for(int j = 0; j< count; j+=1 ) {
                        Console.Write("(" + array[i] + "," + (x - array[i]) + ")");
                    }
                    
                    dict[array[i]] -=1;
                    if(dict[array[i]] == 0){
                        dict.Remove(array[i]);
                    }
                }
            }
            Console.WriteLine();
        }
    }
