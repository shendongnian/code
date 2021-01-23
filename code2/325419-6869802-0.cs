            long trackStart = System.GC.GetTotalMemory(true);
            //your code goes here
            byte[] testData = new byte[50000];
                
            long trackEnd = System.GC.GetTotalMemory(true);
            long diff = trackEnd - trackStart; //You get bytes used.. may not be exact size
