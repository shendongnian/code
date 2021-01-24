    using System;
    
    class Solution {
        public int solution(int[] A) {
            var maxProfit = 0;
            if (A.Length >= 2)
            {
                var minBuyPrice = Math.Min(A[0], A[1]);
                var maxSellPrice = Math.Max(0, A[1] - A[0]);
                maxProfit = maxSellPrice;   
            
                for (int i = 2; i < A.Length; i++)
                {
                    if (minBuyPrice > A[i])
                    {
                        minBuyPrice = A[i];
                        maxSellPrice = A[i];
                    }
                    maxSellPrice = Math.Max(maxSellPrice, A[i]);
                    maxProfit = Math.Max(maxProfit, maxSellPrice - minBuyPrice);
                }
            }
            return maxProfit;
        }
    }
