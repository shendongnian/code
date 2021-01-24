    public class MatrixTest
        {
            public static IEnumerable<object[]> TestData =>
                new List<object[]>
                {
                    new object[]
                    {
                        new int[,]
                        {
                            {7, 1, 3, 3, 2, 1},
                            {1, 3, 9, 8, 5, 6},
                            {4, 6, 7, 9, 1, 0}
                        },
                        new int[,]
                        {
                            {9, 8},
                            {7, 9}
                        },
                        33
                    },
                    new object[]
                    {
                        new int[,]
                        {
                            {10, 11, 12, 13},
                            {14, 15, 16, 17}
                        },
                        new int[,]
                        {
                            {12, 13},
                            {16, 17}
                        },
                        58
                    }
                };
    
    
            [Theory]
            [MemberData(nameof(TestData))]
            public void Test(int[,] input, int[,] expectedArray, int expectedSum)
            {
                MatrixHandler m = new MatrixHandler();
    
                var resp = m.GetMax2x2Matrix(input);
    
                resp.Item1.Should().Be(expectedSum);
    
                resp.Item2.Should().BeEquivalentTo(expectedArray);
            }
        }
    
    
        public class MatrixHandler
        {
            public (int, int[,]) GetMax2x2Matrix(int[,] source)
            {
                var sumsPlusTempArrays = new Dictionary<int, int[,]>();
    
                int[,] temp;
                int sum = 0;
                
                for (int i = 0, n0 = source.GetLength(0) - 1; i <= n0; i++)
                {
                    for (int j = 0, n1 = source.GetLength(1) - 1; j <= n1; j++)
                    {
                        if (i + 1 <= n0 && j + 1 <= n1)
                        {
                            temp = new int[2,2];
                            temp[0, 0] = source[i, j];
                            temp[0, 1] = source[i, j + 1];
                            temp[1, 0] = source[i + 1, j];
                            temp[1, 1] = source[i + 1, j + 1];
                            sum = CalculateSum(temp);
                            sumsPlusTempArrays.TryAdd(sum, temp);
                        }
                    }
                }
    
                var key = sumsPlusTempArrays.Select(x => x.Key).Max();
    
                var value = sumsPlusTempArrays[key];
                
                return (key, value);
            }
    
            private int CalculateSum(int[,] source)
            {
                int sum = 0;
    
                for (int i = 0, n0 = source.GetLength(0); i < n0; i++)
                {
                    for (int j = 0, n1 =  source.GetLength(1); j < n1; j++)
                    {
                        sum += source[i, j];
                    }
                }
                return sum;
            }
        }
