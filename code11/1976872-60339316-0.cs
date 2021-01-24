         `static void Main(string[] args)
          {
            float a = Convert.ToSingle(Console.ReadLine());
            float b = Convert.ToSingle(Console.ReadLine());
            float c = Convert.ToSingle(Console.ReadLine());
            float d = Convert.ToSingle(Console.ReadLine());
            float e = Convert.ToSingle(Console.ReadLine());
            float f = Convert.ToSingle(Console.ReadLine());
            float[] aa = new float[3];
            aa[0] = a;
            aa[1] = c;
            aa[2] = e;
            float[] bb = new float[3];
            bb[0] = b;
            bb[1] = d;
            bb[2] = f;
			
			Array.Sort(aa);
			Array.Sort(bb);
            Console.WriteLine( (aa[0]- aa[1]) * (bb[0]-bb[1]) /2 );
        }`
