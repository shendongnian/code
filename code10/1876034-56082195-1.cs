        private void CleanArray(ref GameObject[] array)
        {
            GameObject[] Temp = new GameObject[0];
            bool First = true;
            bool Tracker = false;
            foreach (GameObject V in array)
            {
                //This is to make sure that there is some value in temp to test against
                if (First)
                {
                    
                    Array.Resize(ref Temp, Temp.Length + 1);
                    Temp[Temp.Length - 1] = V;
                    First = false;
                }
                Tracker = true;
                foreach (GameObject T in Temp)
                {
                    if (T == V)
                    {
                        Tracker = false;
                        break;
                    }
                }
                if(Tracker)
        
                {
                    Array.Resize(ref Temp, Temp.Length + 1);
                    Temp[Temp.Length - 1] = V;
                }
            }
            array = Temp;
        }
