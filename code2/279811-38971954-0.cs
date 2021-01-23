     using System;
    class Solution {
    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        var head = 0; 
        var tail = A.Length -1;
        var absCount = 1;
        var current = A[0] > 0 ? A[0] : -A[0];
        while(head <= tail)
        {
            var former = A[head] > 0 ? A[head] : -A[head];
            if(former == current)
            {
                head ++;
                continue;
            }
            
            var latter = A[tail] > 0 ? A[tail] : -A[tail];
            if(latter == current)
            {
                tail--;
                continue;
            }
        
            if(former >= latter)
            {
                current = former;
                head ++;
            }
            else 
            {
                current = latter;
                tail--;
            
            }
            
            absCount++;
        }
        
        return absCount;
    }
}
