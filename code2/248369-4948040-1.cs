     byte[] a = {1,2,3,4,4,2,3,4,2,5,3,4,4,2,6,3,4,5,3,3};
     List<byte[]> b = new List<byte[]>();
     for (int u=0; u<4; u++)
     {
         byte[] inter_byte= new byte[5];
         for (int p=0; p<5; p++)
         {
             inter_byte[p] = a[(5*u) + p];
         }
         b.Add(inter_byte);
     }        
