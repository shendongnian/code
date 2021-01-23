            public Stack Sum()
            {
                int carry = 0;
                int count = Math.Min(s1.Count, s2.Count);
                for (int i = 0; i < count; i++)
                {
                    var result = Convert.ToInt32(s1.Pop()) + Convert.ToInt32(s2.Pop())
                                 + carry;
                    res.Push(result % 10);
                    carry = (result - result % 10) / 10;
                }
                var carryStream = carry.ToString();
                var remainedStack = s1.Count > 0 ? s1 : s2;
                carry = 0;
                for (int i = carryStream.Length - 1; i >= 0; i--)
                {
                    var result = Convert.ToInt32(carryStream.Substring(i, 1)) 
                 + (remainedStack.Count > 0 ? Convert.ToInt32(remainedStack.Pop()) : 0);
                    res.Push(result % 10);
                    carry = (result - result % 10) / 10;
                }
                if (remainedStack.Count > 0)
                {
                    int remainedCount = remainedStack.Count;
                    for (int i = 0; i < remainedStack.Count; i++)
                    {
                        var result = carry + Convert.ToInt32(remainedStack.Pop());
                        res.Push(result % 10);
                        carry = (result - result % 10) / 10;
                    }
                }
                if (carry != 0)
                    res.Push(carry);
                return res;
            }
