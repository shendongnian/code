            int originalSize = 10;
            object[] sodas = new object[originalSize];
    
            void RemoveSodaAtIndex(int index)
            {
                if(index >= 0 && index < sodas.Length)
                {
                    sodas[index] = null;
                }
            }
    
            void AddSoda(object s)
        {
            for(int i = 0; i < sodas.Length;i++)
            {
                if(sodas[i]==null)
                {
                    sodas[i] = s;
                    return;
                }
            }
            originalSize += 1;
            object[] temp = new object[originalSize];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i != temp.Length - 2)
                {
                    temp[i] = sodas[i];
                }
                else
                {
                    temp[i] = s;
                }
            }
            sodas = temp;
        }
