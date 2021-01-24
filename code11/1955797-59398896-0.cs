    static int ztgzahl(int[] ZL)
            {
                int MinZ = Int16.MinValue; // Min value of Int16 is -32768
                int MaxZ = Int16.MinValue; 
                for(int i = 0; i < ZL.Length; i++) //Iterating over each index of array
                {
                    if (ZL[i] > MaxZ)    //If current element is greater than MaxZ
                    {
                        MinZ = MaxZ;    //MinZ remainsthe same
                        MaxZ = ZL[i];   //MaxZ is the current element
                    }
                    else if (ZL[i] > MinZ) //If current element is greater than MinZ
                    {
                        MinZ = ZL[i];      //MinZ is current element
                    }
                }
                return MinZ;
            }
