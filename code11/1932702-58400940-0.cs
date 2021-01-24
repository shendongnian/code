    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    
    namespace SO_58400592_array_split {
        class Program {
    		private static List<int[]> _testCases = new List<int[]>() {
    			{new int[] {1,1,1,2,1}},
    			{new int[] {2,1,1,2,1}},
    			{new int[] {10,10}}
    		};
    
            static void Main(string[] args) {
    			for (int index = 0; index < _testCases.Count; index++) {
    				Console.WriteLine(CanSplitArray(_testCases[index]));
    			}
    		}
    
    
    
    		static bool CanSplitArray(int[] model) {
    			//	special case of 2 elements
    			if(2 == model.Length) {
    				return model[0] == model[1];
    			}
    
    			// sum the model
    			int sum = model.Sum();
    
    			//	caculate the value from each end
    			int leftSum = 0;
    			int rightSum = sum;
    			//	start at the first index and end at the penultimate index.
    			for (int index = 1; index < model.Length - 1; index++) {
    				leftSum += model[index - 1];
    				rightSum -= model[index - 1];
    				if (leftSum == rightSum) {
    					return true;
    				}
    			}
    
    			return false;
    		}	//	CanSplitArray()
    
        }	//	Program
    }		//	ns
