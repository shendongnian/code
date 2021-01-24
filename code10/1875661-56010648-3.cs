            [Benchmark]
            public void ScalarOp()
            {            
                for (int i = 0; i < data1.Length; i++)
                {
                    sums[i] = data1[i] + data2[i];
                }            
            }
            [Benchmark]
            public void VectorOp()
            {                      
                int ceiling = data1.Length / floatSlots * floatSlots;
                int leftOver = data1.Length % floatSlots;
                for (int i = 0; i < ceiling; i += floatSlots)
                {                
                    Vector<float> v1 = new Vector<float>(data1, i);                
                    Vector<float> v2 = new Vector<float>(data2, i);                
                    (v1 + v2).CopyTo(sums, i); 
                    
                }
                for (int i = ceiling; i < data1.Length; i++)
                {
                    sums[i] = data1[i] + data2[i];
                }
            }
            [Benchmark]
            public void CopyData()
            {                        
                Vector<float> v1 = new Vector<float>(8);
                int ceiling = data1.Length / floatSlots * floatSlots;
                int leftOver = data1.Length % floatSlots;
                for (int i = 0; i < ceiling; i += floatSlots)
                {                               
                    (v1).CopyTo(sums, i);
                }
                for(int i = ceiling; i < data1.Length; i++)
                {
                    sums[i] = 8;
                }                
            }
