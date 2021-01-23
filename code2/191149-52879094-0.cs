    public int[] solution(int[] A, int K) {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length <= 1)
            {
                return A;
            }
            var rotate = K % A.Length;
            var leftSide = A.Length - rotate;
            var arr1 = A.AsParallel().Skip(leftSide).Take(rotate);
            var arr2 = A.AsParallel().Take(leftSide);
            return arr1.Concat(arr2).ToArray();
    }
