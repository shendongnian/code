                const int OBJECT_ID1 = 0;
                const int OBJECT_ID2 = 1;
                const int OBJECT_ID3 = 2;
    
                Dictionary<int, Dictionary<int, float>> MyDict = new Dictionary<int, Dictionary<int, float>>()
                {
                    {
                        OBJECT_ID1, new Dictionary<int, float>()
                        {
                            { OBJECT_ID2, 5.0f },
                            { OBJECT_ID3, 15.0f }
                        }
                    }
                };
