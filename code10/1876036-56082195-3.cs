        private void CleanArray(ref GameObject[] array)
        {
            GameObject[] goTemp = new GameObject[0];
            bool blnFirst = true;
            bool blnTracker = false;
            foreach (GameObject V in array)
            {
                //This is to make sure that there is some value in temp to test against
                if (blnFirst)
                {
                    
                    Array.Resize(ref goTemp, goTemp.Length + 1);
                    goTemp[goTemp.Length - 1] = V;
                    blnFirst = false;
                }
                blnTracker = true;
                foreach (GameObject T in Temp)
                {
                    if (T == V)
                    {
                        blnTracker = false;
                        break;
                    }
                }
                if(blnTracker)
        
                {
                    Array.Resize(ref goTemp, goTemp.Length + 1);
                    goTemp[goTemp.Length - 1] = V;
                }
            }
            array = goTemp;
        }
